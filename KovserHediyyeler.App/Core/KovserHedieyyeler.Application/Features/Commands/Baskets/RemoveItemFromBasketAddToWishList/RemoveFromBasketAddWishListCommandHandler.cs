using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasketAddToWishList
{
    public class RemoveFromBasketAddWishListCommandHandler : IRequestHandler<RemoveFromBasketAddWishListCommandRequest, RemoveFromBasketAddWishListCommandResponse>
    {
        readonly IBasketService _service;

        public RemoveFromBasketAddWishListCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<RemoveFromBasketAddWishListCommandResponse> Handle(RemoveFromBasketAddWishListCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.ProductId == null || request.CustomerId == null) throw new BadRequestException();
            await _service.RemoveItemFromBasketAddWishListAsync(request.ProductId, request.CustomerId);
            return new RemoveFromBasketAddWishListCommandResponse
            {
                Message = "Məhsul Sevimlilər siyahısına əlavə edildi!"
            };
        }
    }
}
