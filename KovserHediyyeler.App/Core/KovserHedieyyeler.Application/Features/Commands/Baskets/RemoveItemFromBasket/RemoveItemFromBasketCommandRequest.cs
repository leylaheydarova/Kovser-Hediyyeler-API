using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandRequest:IRequest<RemoveItemFromBasketCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string CustomerId { get; set; }
    }
}
