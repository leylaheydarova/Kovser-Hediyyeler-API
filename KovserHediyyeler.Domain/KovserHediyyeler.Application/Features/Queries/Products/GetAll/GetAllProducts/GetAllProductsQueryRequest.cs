using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProducts
{
    public class GetAllProductsQueryRequest : GetAllQueryRequest, IRequest<GetAllProductsQueryResponse>
    {
    }
}
