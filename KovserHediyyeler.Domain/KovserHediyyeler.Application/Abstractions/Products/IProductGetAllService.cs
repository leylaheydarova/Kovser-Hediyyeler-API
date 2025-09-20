using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductGetAllService
    {
        public Task<List<ProductGetAllDto>> GetAllProductsAsync(int page, int size);
        public Task<List<ProductImageGetDto>> GetAllProductImagesAsync(int page, int size, Guid productId);
        public Task<List<ProductPropertyGetDto>> GetAllProductPropertiesAsync(int page, int size, Guid productId);
        public Task<List<ProductColorGetDto>> GetAllProductColorsAsync(int page, int size, Guid productId);
        public Task<List<ProductSizeGetDto>> GetAllProductSizesAsync(int page, int size, Guid productId);
        public Task<List<ProductGetAllDto>> GetAllFilteredProductsAsync(int page, int size, Guid BrandIdOrCategoryIdOrDepartmentIdOrShopId);

    }
}
