using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll
{
    public class GetAllProductsQueryRequest:GetAllQueryRequest, IRequest<GetAllProductsQueryResponse>
    {
    }
}
