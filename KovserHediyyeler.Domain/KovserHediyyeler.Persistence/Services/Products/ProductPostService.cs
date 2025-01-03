using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Persistence.Services.Products
{
    public class ProductPostService : IProductPostService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductColorWriteRepository _productColorWriteRepository;
        readonly IProductSizeWriteRepository _productSizeWriteRepository;
        readonly IShopReadRepository _shopReadRepository;
        readonly IShopWriteRepository _shopWriteRepository;
        readonly ICategoryReadRepository _categoryRepository;
        readonly IDepartmentReadRepository _departmentRepository;
        readonly IBrandReadRepository _brandRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public ProductPostService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductColorWriteRepository productColorWriteRepository, IProductSizeWriteRepository productSizeWriteRepository, IShopReadRepository shopReadRepository, IShopWriteRepository shopWriteRepository, ICategoryReadRepository categoryRepository, IDepartmentReadRepository departmentRepository, IBrandReadRepository brandRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productColorWriteRepository = productColorWriteRepository;
            _productSizeWriteRepository = productSizeWriteRepository;
            _shopReadRepository = shopReadRepository;
            _shopWriteRepository = shopWriteRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _brandRepository = brandRepository;
            _env = env;
            _accessor = accessor;
        }

        async Task<Product> GetProductAsync(string id, bool tracking)
        {
            var product = await _productReadRepository.GetWhereAsync(p => p.ID.ToString() == id && !p.isDeleted, tracking);
            if (product == null) throw new NotFoundException("məhsul");
            return product;
        }

        public async Task AddProductShopAsync(string productId, string shopId)
        {
            if (!Guid.TryParse(productId, out Guid productGuid))
                throw new InvalidInputException("məhsul");

            if (!Guid.TryParse(shopId, out Guid shopGuid))
                throw new InvalidInputException("mağaza");

            var product = await _productReadRepository.GetWhereAsync(p => p.ID == productGuid && !p.isDeleted, true);
            if (product == null) throw new NotFoundException("məhsul");

            var shop = await _shopReadRepository.GetWhereAsync(s => s.ID == shopGuid && !s.isDeleted, true);
            if (shop == null) throw new NotFoundException("mağaza");

            shop.Products.Add(product);
            await _shopWriteRepository.SaveAsync();

        }

        public async Task CreateProductAsync(ProductPostDto dto)
        {
            using var transaction = await _productWriteRepository.BeginTransactionAsync();
            try
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

                foreach (var colordto in dto.ProductColors)
                {
                    var color = new ProductColor
                    {
                        ColorName = colordto.ColorName
                    };
                    await _productColorWriteRepository.AddAsync(color);

                }

                foreach (var sizedto in dto.ProductSizes)
                {
                    var size = new ProductSize
                    {
                        SizeName = sizedto.SizeName
                    };
                    await _productSizeWriteRepository.AddAsync(size);

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
                await _productColorWriteRepository.SaveAsync();
                await _productImageFileWriteRepository.SaveAsync();
                await _productPropertyWriteRepository.SaveAsync();
                await _productSizeWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task CreateProductImageAsync(string productId, ProductImageCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            var product = await GetProductAsync(productId, false);
            ProductImageFile image = new ProductImageFile
            {
                ID = Guid.NewGuid(),
                FileName = dto.file.UploadFile(_env.WebRootPath, FilePaths.ProuctImageFilePath),
                Path = "",
                ProductID = product.ID,
                IsMain = dto.IsMain
            };
            image.Path = $"{scheme}://{host}/{FilePaths.ProuctImageFilePath}/{image.FileName}";
            await _productImageFileWriteRepository.AddAsync(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task CreateProductPropertyAsync(string productId, ProductPropertyCommandDto dto)
        {
            var product = await GetProductAsync(productId, false);
            var property = new ProductProperty
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Value = dto.Value,
                ProductID = product.ID
            };
            await _productPropertyWriteRepository.AddAsync(property);
            await _productPropertyWriteRepository.SaveAsync();
        }

        public async Task AddColorToProductAsync(string productId, string colorName)
        {
            var product = await GetProductAsync(productId, false);
            var color = new ProductColor
            {
                ColorName = colorName,
                ProductID = product.ID
            };
            await _productColorWriteRepository.AddAsync(color);
            await _productColorWriteRepository.SaveAsync();
        }

        public async Task AddSizeToProductAsync(string productId, string sizeName)
        {
            var product = await GetProductAsync(productId, false);
            var size = new ProductSize
            {
                SizeName = sizeName,
                ProductID = product.ID
            };
            await _productSizeWriteRepository.AddAsync(size);
            await _productSizeWriteRepository.SaveAsync();
        }

    }
}
