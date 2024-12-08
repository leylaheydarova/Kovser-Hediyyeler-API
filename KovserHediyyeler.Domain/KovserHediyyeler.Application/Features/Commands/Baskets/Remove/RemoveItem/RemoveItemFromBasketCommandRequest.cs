using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Remove.RemoveItem
{
    public class RemoveItemFromBasketCommandRequest : IRequest<RemoveItemFromBasketCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string CustomerId { get; set; }
    }
}
