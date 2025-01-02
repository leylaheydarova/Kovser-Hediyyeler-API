using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductSize
{
    public class GetSingleSizeQueryRequest : GetSingleQueryRequest, IRequest<GetSingleSizeQueryResponse>
    {
    }
}
