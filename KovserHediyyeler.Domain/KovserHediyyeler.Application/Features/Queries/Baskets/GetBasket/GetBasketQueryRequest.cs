using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetBasket
{
    public class GetBasketQueryRequest : IRequest<GetBasketQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
