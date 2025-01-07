using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductPatchService
    {
        public Task UpdateProductAsync(string id, ProductPutDto dto);
        public Task UpdateProductImageFileAsync(string id, ProductImageCommandDto dto);
        public Task UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto);
        public Task UpdateProductColorAsync(string id, string? colorName, int colorStock);
        public Task UpdateProductSizeAsync(string id, string? sizeName, int sizeStock);
    }
}
