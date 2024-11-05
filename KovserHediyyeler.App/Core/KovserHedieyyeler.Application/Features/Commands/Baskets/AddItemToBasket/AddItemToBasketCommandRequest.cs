using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.AddItemToBasket
{
    public class AddItemToBasketCommandRequest:IRequest<AddItemToBasketCommandResponse>
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public string CustomerId { get; set; }
    }
}
