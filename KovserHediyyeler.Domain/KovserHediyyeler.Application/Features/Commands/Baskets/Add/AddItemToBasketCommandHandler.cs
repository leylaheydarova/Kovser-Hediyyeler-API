using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Add
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
            await _service.AddItemToBasketAsync(request.ProductId, request.Count, request.UserId);
            return new AddItemToBasketCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul səbətə uğurla əlavə olundu!"
            };
        }
    }
}
