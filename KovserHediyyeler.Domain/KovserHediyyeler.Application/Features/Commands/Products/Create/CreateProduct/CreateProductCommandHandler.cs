using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductService _service;

        public CreateProductCommandHandler(IProductService service)
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
