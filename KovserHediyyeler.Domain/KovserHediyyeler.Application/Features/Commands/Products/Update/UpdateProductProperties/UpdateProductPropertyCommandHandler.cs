using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductProperties
{
    public class UpdateProductPropertyCommandHandler : IRequestHandler<UpdateProductPropertyCommandRequest, UpdateProductPropertyCommandResponse>
    {
        readonly IProductPatchService _service;

        public UpdateProductPropertyCommandHandler(IProductPatchService service)
        {
            _service = service;
        }

        public async Task<UpdateProductPropertyCommandResponse> Handle(UpdateProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateProductPropertyAsync(request.Id, request.Dto);
            return new UpdateProductPropertyCommandResponse
            {

                Message = "Məhsul xassəsi uğurla yeniləndi!"
            };
        }
    }
}
