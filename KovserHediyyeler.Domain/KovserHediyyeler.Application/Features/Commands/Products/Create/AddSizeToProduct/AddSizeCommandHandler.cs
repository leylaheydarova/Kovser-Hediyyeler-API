using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddSizeToProduct
{
    public class AddSizeCommandHandler : IRequestHandler<AddSizeCommandRequest, AddSizeCommandResponse>
    {
        readonly IProductService _service;

        public AddSizeCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<AddSizeCommandResponse> Handle(AddSizeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddSizeToProductAsync(request.ProductId, request.SizeName);
            return new AddSizeCommandResponse
            {
                Message = "Məhsul ölçüsü uğurla artırıldı!"
            };
        }
    }
}
