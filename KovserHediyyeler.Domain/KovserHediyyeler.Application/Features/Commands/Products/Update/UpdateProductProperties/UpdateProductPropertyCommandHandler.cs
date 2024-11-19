using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductProperties
{
    public class UpdateProductPropertyCommandHandler : IRequestHandler<UpdateProductPropertyCommandRequest, UpdateProductPropertyCommandResponse>
    {
        readonly IProductService _service;

        public UpdateProductPropertyCommandHandler(IProductService service)
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
