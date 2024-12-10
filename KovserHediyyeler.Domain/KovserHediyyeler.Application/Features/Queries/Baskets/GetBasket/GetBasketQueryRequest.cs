using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetBasket
{
    public class GetBasketQueryRequest : GetSingleQueryRequest, IRequest<GetBasketQueryResponse>
    {
    }
}
