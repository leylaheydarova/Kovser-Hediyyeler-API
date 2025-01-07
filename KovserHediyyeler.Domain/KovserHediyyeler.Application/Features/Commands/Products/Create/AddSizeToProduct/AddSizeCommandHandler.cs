using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddSizeToProduct
{
    public class AddSizeCommandHandler : IRequestHandler<AddSizeCommandRequest, AddSizeCommandResponse>
    {
        readonly IProductPostService _service;

        public AddSizeCommandHandler(IProductPostService service)
        {
            _service = service;
        }

        public async Task<AddSizeCommandResponse> Handle(AddSizeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddSizeToProductAsync(request.ProductId, request.SizeName, request.SizeStock);
            return new AddSizeCommandResponse
            {
                Message = "Məhsul ölçüsü uğurla artırıldı!"
            };
        }
    }
}
