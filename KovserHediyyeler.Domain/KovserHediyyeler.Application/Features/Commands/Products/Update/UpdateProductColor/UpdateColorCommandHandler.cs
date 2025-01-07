using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductColor
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommandRequest, UpdateColorCommandResponse>
    {
        readonly IProductPatchService _service;

        public UpdateColorCommandHandler(IProductPatchService service)
        {
            _service = service;
        }

        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateProductColorAsync(request.ID, request.ColorName, request.ColorStock);
            return new UpdateColorCommandResponse
            {
                Message = "Rəng uğurla yeniləndi!"
            };
        }
    }
}
