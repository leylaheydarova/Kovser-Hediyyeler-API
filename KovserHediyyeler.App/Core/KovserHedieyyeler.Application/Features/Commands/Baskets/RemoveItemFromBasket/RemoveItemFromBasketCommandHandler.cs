using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandHandler : IRequestHandler<RemoveItemFromBasketCommandRequest, RemoveItemFromBasketCommandResponse>
    {
        readonly IBasketService _service;

        public RemoveItemFromBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<RemoveItemFromBasketCommandResponse> Handle(RemoveItemFromBasketCommandRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new BadRequestException();
            await _service.RemoveItemFromBasketAsync(request.ProductId, request.CustomerId);
            return new RemoveItemFromBasketCommandResponse
            {
                Message = "Məhsul uğurla səbətdən silindi!"
            };
        }
    }
}
