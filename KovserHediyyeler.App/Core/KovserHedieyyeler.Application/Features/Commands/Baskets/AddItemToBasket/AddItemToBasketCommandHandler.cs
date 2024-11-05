using KovserHedieyyeler.Application.Abstractions.Services;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        readonly IBasketService _service;

        public AddItemToBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddItemToBasketAsync(request.ProductId, request.Count, request.CustomerId);
            return new AddItemToBasketCommandResponse()
            {
                Message = "Məhsul səbətə uğurla əlavə edildi!"
            };
        }
    }
}
