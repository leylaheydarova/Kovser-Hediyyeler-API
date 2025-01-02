using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IProductService
    {
        //Post
        public Task CreateProductAsync(ProductPostDto dto);
        public Task CreateProductImageAsync(string productId, ProductImageCommandDto dto);
        public Task CreateProductPropertyAsync(string productId, ProductPropertyCommandDto dto);
        public Task AddProductShopAsync(string productId, string shopId);
        public Task AddColorToProductAsync(string productId, string colorName);
        public Task AddSizeToProductAsync(string productId, string sizeName);

        //Delete
        public Task RemovePermanentlyProductAsync(string id);
        public Task RemovePermanentlyProductImageFileAsync(string id);
        public Task RemovePermanentlyProductPropertyAsync(string id);
        public Task RemovePermanentlyProductShopAsync(string prodcutId, string shopId);
        public Task RemovePermanentlyProductColorAsync(string id);
        public Task RemovePermanentlyProductSizeAsync(string id);
        public Task DeleteTemporarilyProductAsync(string id);
        public Task RecoverProductDataAsync(string id);

        //Patch
        public Task UpdateProductAsync(string id, ProductPutDto dto);
        public Task UpdateProductImageFileAsync(string id, ProductImageCommandDto dto);
        public Task UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto);
        public Task UpdateProductColorAsync(string id, string colorName);
        public Task UpdateProductSizeAsync(string id, string sizeName);

        //Get
        public Task<List<ProductGetAllDto>> GetAllProductsAsync(int page, int size);
        public Task<List<ProductImageGetDto>> GetAllProductImagesAsync(int page, int size, string productId);
        public Task<List<ProductPropertyGetDto>> GetAllProductPropertiesAsync(int page, int size, string productId);
        public Task<List<ProductColorGetDto>> GetAllProductColorsAsync(int page, int size, string productId);
        public Task<List<ProductSizeGetDto>> GetAllProductSizesAsync(int page, int size, string productId);
        public Task<List<ProductGetAllDto>> GetAllFilteredProductsAsync(int page, int size, string BrandIdOrCategoryIdOrDepartmentIdOrShopId);

        public Task<ProductGetSingleDto> GetSingleProductAsync(string id);
        public Task<ProductPropertyGetDto> GetSingleProductPropertyAsync(string id);
        public Task<ProductColorGetDto> GetSingleProductColorAsync(string id);
        public Task<ProductSizeGetDto> GetSingleProductSizeAsync(string id);

    }
}
