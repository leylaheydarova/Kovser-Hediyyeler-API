using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KovserHediyyeler.Persistence.Services.Products
{
    public class ProductGetAllService : IProductGetAllService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductPropertyReadRepository _productPropertyReadRepository;
        readonly IProductColorReadRepository _productColorReadRepository;
        readonly IProductSizeReadRepository _productSizeReadRepository;

        public ProductGetAllService(IProductReadRepository productReadRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductPropertyReadRepository productPropertyReadRepository, IProductColorReadRepository productColorReadRepository, IProductSizeReadRepository productSizeReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productPropertyReadRepository = productPropertyReadRepository;
            _productColorReadRepository = productColorReadRepository;
            _productSizeReadRepository = productSizeReadRepository;
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

        public async Task<List<ProductImageGetDto>> GetAllProductImagesAsync(int page, int size, Guid productId)
        {
            var query = _productImageFileReadRepository
                .GetAllWhere(x => x.ProductID == productId, false)
                .Select(x => new ProductImageGetDto
                {
                    Id = x.ID.ToString(),
                    ImageName = x.FileName != null ? x.FileName : ConstantPaths.DefaultImage,
                    ImageURL = x.FileName != null ? x.Path : ConstantPaths.DefaultImageURL,
                    isMain = x.IsMain
                });

            return await PaginateAsync(query, page, size);
        }

        public async Task<List<ProductPropertyGetDto>> GetAllProductPropertiesAsync(int page, int size, Guid productId)
        {
            var query = _productPropertyReadRepository
                .GetAllWhere(x => !x.isDeleted && x.ProductID == productId, false)
                .Select(x => new ProductPropertyGetDto
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

        public async Task<List<ProductGetAllDto>> GetAllFilteredProductsAsync(int page, int size, Guid BrandIdOrCategoryIdOrDepartmentIdOrShopId)
        {
            var query = GetFilteredProductsQuery(
                x => !x.isDeleted &&
                     (x.BrandID == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.CategoryID == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.DepartmentID == BrandIdOrCategoryIdOrDepartmentIdOrShopId ||
                      x.Shops.Any(sh => sh.ID == BrandIdOrCategoryIdOrDepartmentIdOrShopId))
            );

            return await PaginateAsync(query, page, size);
        }

        public async Task<List<ProductColorGetDto>> GetAllProductColorsAsync(int page, int size, Guid productId)
        {
            var query = _productColorReadRepository
               .GetAllWhere(x => !x.isDeleted && x.ProductID == productId, false)
               .Select(x => new ProductColorGetDto
               {
                   Id = x.ID.ToString(),
                   ColorName = x.ColorName
               });

            return await PaginateAsync(query, page, size);
        }

        public async Task<List<ProductSizeGetDto>> GetAllProductSizesAsync(int page, int size, Guid productId)
        {
            var query = _productSizeReadRepository
               .GetAllWhere(x => !x.isDeleted && x.ProductID == productId, false)
               .Select(x => new ProductSizeGetDto
               {
                   Id = x.ID.ToString(),
                   SizeName = x.SizeName
               });

            return await PaginateAsync(query, page, size);
        }

    }
}
