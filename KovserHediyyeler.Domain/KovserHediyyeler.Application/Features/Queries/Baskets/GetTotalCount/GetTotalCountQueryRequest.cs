using KovserHedieyyeler.Application.Features;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalCount
{
    public class GetTotalCountQueryRequest : IdRequest, IRequest<GetTotalCountQueryResponse>
    {
    }
}
