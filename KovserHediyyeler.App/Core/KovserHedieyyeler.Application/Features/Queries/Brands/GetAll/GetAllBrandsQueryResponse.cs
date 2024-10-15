using KovserHedieyyeler.Application.DTOs.Brands;


namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryResponse
    {
        public List<BrandGetDto> Dtos { get; set; }
        public int TotalCount { get; set; }
    }
}
