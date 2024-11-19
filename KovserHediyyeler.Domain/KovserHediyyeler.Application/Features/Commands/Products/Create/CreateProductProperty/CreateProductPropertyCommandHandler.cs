using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProductProperty
{
    public class CreateProductPropertyCommandHandler : IRequestHandler<CreateProductPropertyCommandRequest, CreateProductPropertyCommandResponse>
    {
        readonly IProductService _service;

        public CreateProductPropertyCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<CreateProductPropertyCommandResponse> Handle(CreateProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateProductPropertyAsync(request.ProductId, request.Dto);

            return new CreateProductPropertyCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul xüsusiyyəti uğurla əlavə edildi!"
            };
        }
    }
}
