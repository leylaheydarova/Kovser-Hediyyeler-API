using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductGetSingleService
    {
        public Task<ProductGetSingleDto> GetSingleProductAsync(Guid id);
        public Task<ProductPropertyGetDto> GetSingleProductPropertyAsync(Guid id);
        public Task<ProductColorGetDto> GetSingleProductColorAsync(Guid id);
        public Task<ProductSizeGetDto> GetSingleProductSizeAsync(Guid id);
    }
}
