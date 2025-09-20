using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetAll.GetAllCategoryProducts
{
    public class GetAllFilteredProductsQueryRequest : GetAllQueryRequest, IRequest<GetAllFilteredProductsQueryResponse>
    {
        public Guid BrandIdOrCategoryIdOrDepartmentIdOrShopId { get; set; }
    }
}
