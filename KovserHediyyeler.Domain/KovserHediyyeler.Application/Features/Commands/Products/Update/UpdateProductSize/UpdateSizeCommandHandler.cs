using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductSize
{
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommandRequest, UpdateSizeCommandResponse>
    {
        readonly IProductService _service;

        public UpdateSizeCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<UpdateSizeCommandResponse> Handle(UpdateSizeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateProductSizeAsync(request.ID, request.SizeName);
            return new UpdateSizeCommandResponse
            {
                Message = "Ölçü uğurla yeniləndi!"
            };
        }
    }
}
