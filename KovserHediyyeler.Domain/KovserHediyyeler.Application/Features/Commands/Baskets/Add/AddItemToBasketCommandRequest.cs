using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Add
{
    public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}
