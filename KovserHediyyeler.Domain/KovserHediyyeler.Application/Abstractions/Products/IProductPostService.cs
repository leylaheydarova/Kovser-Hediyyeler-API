using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductPostService
    {
        public Task CreateProductAsync(ProductPostDto dto);
        public Task CreateProductImageAsync(string productId, ProductImageCommandDto dto);
        public Task CreateProductPropertyAsync(string productId, ProductPropertyCommandDto dto);
        public Task AddProductShopAsync(string productId, string shopId);
        public Task AddColorToProductAsync(string productId, string colorName);
        public Task AddSizeToProductAsync(string productId, string sizeName);
    }
}
