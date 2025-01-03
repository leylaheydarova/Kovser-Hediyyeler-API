using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;

namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductGetSingleService
    {
        public Task<ProductGetSingleDto> GetSingleProductAsync(string id);
        public Task<ProductPropertyGetDto> GetSingleProductPropertyAsync(string id);
        public Task<ProductColorGetDto> GetSingleProductColorAsync(string id);
        public Task<ProductSizeGetDto> GetSingleProductSizeAsync(string id);
    }
}
