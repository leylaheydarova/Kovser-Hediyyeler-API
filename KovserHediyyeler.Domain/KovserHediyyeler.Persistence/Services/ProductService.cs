using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KovserHediyyeler.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductPropertyReadRepository _productPropertyReadRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IColorWriteRepository _colorWriteRepository;
        readonly IShopReadRepository _shopReadRepository;
        readonly IShopWriteRepository _shopWriteRepository;
        readonly IProductShopWriteRepository _productShopWriteRepository;
        readonly ICategoryReadRepository _categoryRepository;
        readonly IDepartmentReadRepository _departmentRepository;
        readonly IBrandReadRepository _brandRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;


        public ProductService(IProductWriteRepository productWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IColorWriteRepository colorWriteRepository, IShopReadRepository shopReadRepository, ICategoryReadRepository categoryRepository, IDepartmentReadRepository departmentRepository, IBrandReadRepository brandRepository, IProductReadRepository productReadRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductPropertyReadRepository productPropertyReadRepository, IShopWriteRepository shopWriteRepository, IProductShopWriteRepository productShopWriteRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productPropertyReadRepository = productPropertyReadRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productShopWriteRepository = productShopWriteRepository;
            _colorWriteRepository = colorWriteRepository;
            _shopReadRepository = shopReadRepository;
            _shopWriteRepository = shopWriteRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _brandRepository = brandRepository;
            _env = env;
            _accessor = accessor;
        }
        private IQueryable<ProductGetAllDto> GetFilteredProductsQuery(Expression<Func<Product, bool>> filter)
        {
            return _productReadRepository.GetAllWhere(filter, false, "Department", "Shops")
                .Select(x => new ProductGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    DepartmentName = x.Department.Name,
                    DiscountedPrice = x.DiscountedPrice,
                    Price = x.Price,
                    ProductAverageRating = x.ProductAverageRating,
                    Image = x.Images
                        .Where(image => image.IsMain)
                        .Select(image => new ProductImageGetDto
                        {
                            Id = image.ID.ToString(),
                            ImageName = image.FileName,
                            ImageURL = image.Path,
                            isMain = image.IsMain
                        })
                        .FirstOrDefault()
                        ?? new ProductImageGetDto
                        {
                            Id = Guid.NewGuid().ToString(),
                            ImageName = ConstantPaths.DefaultImage,
                            ImageURL = ConstantPaths.DefaultImageURL,
                            isMain = true
                        }
                });
        }

        async Task<List<T>> PaginateAsync<T>(IQueryable<T> query, int page, int size)
        {
            return await query
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task AddProductShopAsync(string productId, string shopId)
        {
            if (!Guid.TryParse(productId, out Guid productGuid))
                throw new InvalidInputException("məhsul");

            if (!Guid.TryParse(shopId, out Guid shopGuid))
                throw new InvalidInputException("mağaza");

            var product = await _productReadRepository.GetWhereAsync(p => p.ID == productGuid && !p.isDeleted, true);
            if (product == null) throw new ProductNotFoundException();

            var shop = await _shopReadRepository.GetWhereAsync(s => s.ID == shopGuid && !s.isDeleted, true);
            if (shop == null) throw new ShopNotFoundException();

            shop.Products.Add(product);
            await _shopWriteRepository.SaveAsync();

        }

        public async Task CreateProductAsync(ProductPostDto dto)
        {
            var category = await _categoryRepository.GetWhereAsync(c => c.ID == dto.CategoryID, false, "ParentCategory");
            if (category == null) throw new InvalidInputException("kateqoriya");

            var department = await _departmentRepository.GetWhereAsync(d => d.ID == dto.DepartmentID, false);
            if (department == null) throw new InvalidInputException("şöbə");
            var brand = dto.BrandID is not null
                ? await _brandRepository.GetWhereAsync(b => b.ID == dto.BrandID, false)
                : null;

            if (brand == null && dto.BrandID is not null)
                throw new InvalidInputException("brend");

            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;

            Product product = new Product
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                BrandID = brand.ID,
                CategoryID = category.ID,
                DepartmentID = department.ID,
                Price = dto.Price,
                DiscountedPrice = (dto.Price - ((dto.Price * (int)dto.DiscountPercentage) / 100)),
                isSingleColour = dto.isSingleColour,
                Stock = dto.Stock
            };


            foreach (var imagedto in dto.ProductImages)
            {
                var res = imagedto.file.FileName;

                ProductImageFile image = new ProductImageFile
                {
                    ID = Guid.NewGuid(),
                    FileName = imagedto.file.UploadFile(_env.WebRootPath, FilePaths.ProuctImageFilePath),
                    Path = "",
                    ProductID = product.ID,
                    IsMain = imagedto.IsMain
                };
                image.Path = $"{scheme}://{host}/{FilePaths.ProuctImageFilePath}/{image.FileName}";
                try
                {
                    await _productImageFileWriteRepository.AddAsync(image);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            foreach (var colordto in dto.Colors)
            {
                ColorCode color = new ColorCode
                {
                    ID = Guid.NewGuid(),
                    Name = colordto.Name,
                    HexCode = colordto.HexCode
                };

                var propertycolor = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = "rəng",
                    Value = color.Name,
                    ProductID = product.ID
                };
                await _productPropertyWriteRepository.AddAsync(propertycolor);
                await _colorWriteRepository.AddAsync(color);
            }

            foreach (var propertydto in dto.ProductProperties)
            {
                ProductProperty property = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = propertydto.Name,
                    Value = propertydto.Value,
                    ProductID = product.ID
                };

                await _productPropertyWriteRepository.AddAsync(property);
            }

            foreach (var shopId in dto.ShopIDs)
            {
                var shop = await _shopReadRepository.GetWhereAsync(sh => sh.ID == shopId && !sh.isDeleted, true);
                if (shop != null)
                {
                    product.Shops.Add(shop);
                }
                else throw new InvalidInputException("mağaza");
            }

            category.Products.Add(product);
            department.Products.Add(product);
            if (brand is not null) brand.Products.Add(product);
            try
            {
                await _productWriteRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            await _productWriteRepository.SaveAsync();
        }

        public async Task CreateProductImageAsync(string productId, ProductImageCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            ProductImageFile image = new ProductImageFile
            {
                ID = Guid.NewGuid(),
                FileName = dto.file.UploadFile(_env.WebRootPath, FilePaths.ProuctImageFilePath),
                Path = "",
                ProductID = Guid.Parse(productId),
                IsMain = dto.IsMain
            };
            image.Path = $"{scheme}://{host}/{FilePaths.ProuctImageFilePath}/{image.FileName}";
            await _productImageFileWriteRepository.AddAsync(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task CreateProductPropertyAsync(string productId, ProductPropertyCommandDto dto)
        {
            ProductProperty property = new ProductProperty
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Value = dto.Value,
                ProductID = Guid.Parse(productId)
            };
            await _productPropertyWriteRepository.AddAsync(property);
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyProductAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true, "Properties");
            if (product == null) throw new ProductNotFoundException();
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.DeleteTemporarily(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.DeleteTemporarily(comment);
            //}
            _productWriteRepository.DeleteTemporarily(product);
            await _productPropertyWriteRepository.SaveAsync();
            await _productWriteRepository.SaveAsync();
        }

        public async Task<List<ProductImageGetDto>> GetAllProductImagesAsync(int page, int size, string productId)
        {
            var query = _productImageFileReadRepository
                .GetAllWhere(x => x.ProductID.ToString() == productId, false)
                .Select(x => new ProductImageGetDto
                {
                    Id = x.ID.ToString(),
                    ImageName = x.FileName != null ? x.FileName : ConstantPaths.DefaultImage,
                    ImageURL = x.FileName != null ? x.Path : ConstantPaths.DefaultImageURL,
                    isMain = x.IsMain
                });

            return await PaginateAsync(query, page, size);
        }

        public async Task<List<ProductPropertyGetAllDto>> GetAllProductPropertiesAsync(int page, int size, string productId)
        {
            var query = _productPropertyReadRepository
                .GetAllWhere(x => !x.isDeleted && x.ProductID.ToString() == productId, false)
                .Select(x => new ProductPropertyGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Value = x.Value
                });

            return await PaginateAsync(query, page, size);
        }

        public async Task<List<ProductGetAllDto>> GetAllProductsAsync(int page, int size)
        {
            var query = GetFilteredProductsQuery(x => !x.isDeleted);
            return await PaginateAsync(query, page, size);
        }

        public async Task RecoverProductDataAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => x.isDeleted && x.ID.ToString() == id, true, "Properties");
            if (product == null) throw new ProductNotFoundException();

            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.RecoverData(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.RecoverData(comment);
            //}
            _productWriteRepository.RecoverData(product);
            await _productWriteRepository.SaveAsync();
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(p => p.ID.ToString() == id, true, "Images", "Properties");

            if (product == null) throw new ProductNotFoundException();
            foreach (var image in product.Images)
            {
                _productImageFileWriteRepository.RemovePermanently(image);
            }
            foreach (var property in product.Properties)
            {
                _productPropertyWriteRepository.RemovePermanently(property);
            }
            //foreach (var comment in product.Comments)
            //{
            //    _productCommentWriteRepository.RemovePermanently(comment);
            //}
            _productWriteRepository.RemovePermanently(product);
            await _productWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductImageFileAsync(string id)
        {
            ProductImageFile image = await _productImageFileReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (image == null) throw new ProductImageNotFoundException();
            _productImageFileWriteRepository.RemovePermanently(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductPropertyAsync(string id)
        {
            ProductProperty property = await _productPropertyReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (property == null) throw new ProductPropertyNotFoundException();
            _productPropertyWriteRepository.RemovePermanently(property);
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task RemovePermanentlyProductShopAsync(string prodcutId, string shopId)
        {
            await _productShopWriteRepository.RemovePermanentlyProductShopAsync(prodcutId, shopId);
        }

        public async Task UpdateProductAsync(string id, ProductPutDto dto)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true);
            if (product == null) throw new ProductNotFoundException();
            var discountprice = dto.Price - dto.Price * (int)dto.DiscountPercentage / 100;
            product.Name = dto.Name != null ? dto.Name : product.Name;
            product.Description = dto.Description != null ? dto.Description : product.Description;
            product.Stock = dto.Stock != null ? dto.Stock : product.Stock;
            product.Price = dto.Price != null ? dto.Price : product.Price;
            product.DiscountedPrice = dto.DiscountPercentage == null ? product.DiscountedPrice : discountprice;
            product.isSingleColour = dto.isSingleColour != null ? dto.isSingleColour : product.isSingleColour;
            product.BrandID = dto.BrandID != null ? dto.BrandID : product.BrandID;
            product.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : product.DepartmentID;
            product.CategoryID = dto.CategoryID != null ? (Guid)dto.CategoryID : product.CategoryID;

            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
        }

        public async Task UpdateProductImageFileAsync(string id, ProductImageCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            ProductImageFile image = await _productImageFileReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true);
            if (image == null) throw new ProductImageNotFoundException();
            image.FileName = dto.file != null ? dto.file.UploadFile(_env.WebRootPath, FilePaths.ProuctImageFilePath) : image.FileName != null ? image.FileName : ConstantPaths.DefaultImage;
            image.Path = dto.file != null
                ? $"{scheme}://{host}/{FilePaths.ProuctImageFilePath}/{image.FileName}"
                : image.Path != null ? image.Path : ConstantPaths.DefaultImageURL;
            image.IsMain = dto.IsMain != null ? (bool)dto.IsMain : image.IsMain;

            _productImageFileWriteRepository.Update(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto)
        {
            ProductProperty property = await _productPropertyReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true);
            if (property == null) throw new ProductPropertyNotFoundException();
            property.Name = dto.Name != null ? dto.Name : property.Name;
            property.Value = dto.Value != null ? dto.Value : property.Value;

            _productPropertyWriteRepository.Update(property);
            await _productPropertyWriteRepository.SaveAsync();

        }

        public async Task<List<ProductGetAllDto>> GetAllFilteredProductsAsync(int page, int size, string BrandIdOrCategoryIdOrDepartmentIdOrShopId)
        {
            var query = GetFilteredProductsQuery(
                x => !x.isDeleted &&
                     (x.BrandID.ToString() == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.CategoryID.ToString() == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.DepartmentID.ToString() == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.Shops.Any(sh => sh.ID.ToString() == BrandIdOrCategoryIdOrDepartmentIdOrShopId))
            );

            return await PaginateAsync(query, page, size);
        }
    }
}
