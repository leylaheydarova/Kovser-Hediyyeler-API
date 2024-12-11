using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface ISearchService
    {
        Task<List<ProductGetAllDto>> SearchProducts(string query);
    }
}
