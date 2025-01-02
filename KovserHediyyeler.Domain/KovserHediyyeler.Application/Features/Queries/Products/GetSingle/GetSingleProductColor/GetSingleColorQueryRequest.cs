using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductColor
{
    public class GetSingleColorQueryRequest : GetSingleQueryRequest, IRequest<GetSingleColorQueryResponse>
    {
    }
}
