using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductPatchService
    {
        public Task UpdateProductAsync(Guid id, ProductPutDto dto);
        public Task UpdateProductImageFileAsync(Guid id, ProductImageCommandDto dto);
        public Task UpdateProductPropertyAsync(Guid id, ProductPropertyCommandDto dto);
        public Task UpdateProductColorAsync(Guid id, string? colorName, int colorStock);
        public Task UpdateProductSizeAsync(Guid id, string? sizeName, int sizeStock);
    }
}
