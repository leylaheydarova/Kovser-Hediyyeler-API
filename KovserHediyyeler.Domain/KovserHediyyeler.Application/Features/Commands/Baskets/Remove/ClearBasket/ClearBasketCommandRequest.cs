using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Remove.ClearBasket
{
    public class ClearBasketCommandRequest : IRequest<ClearBasketCommandResponse>
    {
        public string CustomerId { get; set; }
    }
}
