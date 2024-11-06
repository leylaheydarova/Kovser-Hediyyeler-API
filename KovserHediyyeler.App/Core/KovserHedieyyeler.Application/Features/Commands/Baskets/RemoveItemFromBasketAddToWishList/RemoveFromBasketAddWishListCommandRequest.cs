using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasketAddToWishList
{
    public class RemoveFromBasketAddWishListCommandRequest:IRequest<RemoveFromBasketAddWishListCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string CustomerId { get; set; }
    }
}
