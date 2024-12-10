using KovserHedieyyeler.Application.Features;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalPrice
{
    public class GetTotalPriceQueryRequest : IdRequest, IRequest<GetTotalPriceQueryResponse>
    {
    }
}
