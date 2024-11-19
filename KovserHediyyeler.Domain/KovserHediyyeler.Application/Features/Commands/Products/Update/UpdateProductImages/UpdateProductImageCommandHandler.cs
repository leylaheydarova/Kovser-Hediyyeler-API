using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductImages
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, UpdateProductImageCommandResponse>
    {
        readonly IProductService _service;

        public UpdateProductImageCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateProductImageFileAsync(request.Id, request.Dto);
            return new UpdateProductImageCommandResponse
            {
                Message = "Məhsul şəkli uğurla yeniləndi!"
            };
        }
    }
}
