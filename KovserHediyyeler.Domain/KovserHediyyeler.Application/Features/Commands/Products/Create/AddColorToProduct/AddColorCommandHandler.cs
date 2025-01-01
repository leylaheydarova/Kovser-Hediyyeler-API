using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddColorToProduct
{
    public class AddColorCommandHandler : IRequestHandler<AddColorCommandRequest, AddColorCommandResponse>
    {
        readonly IProductService _service;

        public AddColorCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<AddColorCommandResponse> Handle(AddColorCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddColorToProductAsync(request.ProductId, request.ColorName);
            return new AddColorCommandResponse
            {
                Message = "Məhsul rəngi uğurla artırılmışdır!"
            };
        }
    }
}
