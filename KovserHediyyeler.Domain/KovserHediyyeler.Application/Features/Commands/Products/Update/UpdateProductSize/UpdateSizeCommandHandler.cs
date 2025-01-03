using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductSize
{
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommandRequest, UpdateSizeCommandResponse>
    {
        readonly IProductPatchService _service;

        public UpdateSizeCommandHandler(IProductPatchService service)
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
