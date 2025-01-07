using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddColorToProduct
{
    public class AddColorCommandHandler : IRequestHandler<AddColorCommandRequest, AddColorCommandResponse>
    {
        readonly IProductPostService _service;

        public AddColorCommandHandler(IProductPostService service)
        {
            _service = service;
        }

        public async Task<AddColorCommandResponse> Handle(AddColorCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddColorToProductAsync(request.ProductId, request.ColorName, request.ColorStock);
            return new AddColorCommandResponse
            {
                Message = "Məhsul rəngi uğurla artırılmışdır!"
            };
        }
    }
}
