using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductImage
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, CreateProductImageCommandResponse>
    {
        readonly IProductPostService _service;

        public CreateProductImageCommandHandler(IProductPostService service)
        {
            _service = service;
        }

        public async Task<CreateProductImageCommandResponse> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateProductImageAsync(request.ProductId, request.Dto);

            return new CreateProductImageCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul şəkli uğurla yüklənmişdir"
            };
        }
    }
}
