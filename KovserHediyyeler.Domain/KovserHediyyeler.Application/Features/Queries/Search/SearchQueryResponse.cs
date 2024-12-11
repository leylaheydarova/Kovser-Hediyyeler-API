using KovserHedieyyeler.Application.DTOs.Products.Products;

namespace KovserHediyyeler.Application.Features.Queries.Search
{
    public class SearchQueryResponse
    {
        public int StatusCode { get; set; } = 200;
        public List<ProductGetAllDto> Products { get; set; }
    }
}
