using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IProductService
    {
        //Post
        public Task CreateProductAsync(ProductPostDto dto);
        public Task CreateProductImageAsync(string productId, ProductImageCommandDto dto);
        public Task CreateProductPropertyAsync(string productId, ProductPropertyCommandDto dto);
        public Task AddProductShopAsync(string productId, string shopId);
        //Delete
        public Task RemovePermanentlyProductAsync(string id);
        public Task RemovePermanentlyProductImageFileAsync(string id);
        public Task RemovePermanentlyProductPropertyAsync(string id);
        public Task RemovePermanentlyProductShopAsync(string prodcutId, string shopId);
        public Task DeleteTemporarilyProductAsync(string id);
        public Task RecoverProductDataAsync(string id);
        //Patch
        public Task UpdateProductAsync(string id, ProductPutDto dto);
        public Task UpdateProductImageFileAsync(string id, ProductImageCommandDto dto);
        public Task UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto);

        //Get
        public Task<List<ProductGetAllDto>> GetAllProductsAsync(int page, int size);
        public Task<List<ProductImageGetDto>> GetAllProductImagesAsync(int page, int size, string productId);
        public Task<List<ProductPropertyGetAllDto>> GetAllProductPropertiesAsync(int page, int size, string productId);
        public Task<List<ProductGetAllDto>> GetAllFilteredProductsAsync(int page, int size, string filterId);




    }
}
