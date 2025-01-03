using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductPostService _service;

        public CreateProductCommandHandler(IProductPostService service)
        {
            _service = service;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateProductAsync(request.Dto);

            return new CreateProductCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul uğurla əlavə edildi!"
            };
        }
    }
}
