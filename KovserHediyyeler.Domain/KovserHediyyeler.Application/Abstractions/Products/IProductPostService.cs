using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductPostService
    {
        public Task CreateProductAsync(ProductPostDto dto);
        public Task CreateProductImageAsync(Guid productId, ProductImageCommandDto dto);
        public Task CreateProductPropertyAsync(Guid productId, ProductPropertyCommandDto dto);
        public Task AddProductShopAsync(Guid productId, Guid shopId);
        public Task AddColorToProductAsync(Guid productId, string colorName, int colorStock);
        public Task AddSizeToProductAsync(Guid productId, string sizeName, int sizeStock);
    }
}
