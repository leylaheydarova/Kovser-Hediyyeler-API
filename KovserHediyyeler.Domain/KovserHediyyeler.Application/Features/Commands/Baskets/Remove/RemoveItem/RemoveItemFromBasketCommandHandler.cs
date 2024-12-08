using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Remove.RemoveItem
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
            await _service.RemoveItemFromBasketAsync(request.ProductId, request.CustomerId);
            return new RemoveItemFromBasketCommandResponse
            {
                Message = "Məhsul səbətdən uğurla silindi!"
            };
        }
    }
}
