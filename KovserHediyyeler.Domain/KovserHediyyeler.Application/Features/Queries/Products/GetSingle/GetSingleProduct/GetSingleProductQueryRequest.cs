using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProduct
{
    public class GetSingleProductQueryRequest : GetSingleQueryRequest, IRequest<GetSingleProductQueryResponse>
    {
    }
}
