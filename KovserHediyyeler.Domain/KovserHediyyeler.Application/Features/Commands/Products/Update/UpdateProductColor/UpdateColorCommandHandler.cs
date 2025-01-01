using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductColor
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommandRequest, UpdateColorCommandResponse>
    {
        readonly IProductService _service;

        public UpdateColorCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateProductColorAsync(request.ID, request.ColorName);
            return new UpdateColorCommandResponse
            {
                Message = "Rəng uğurla yeniləndi!"
            };
        }
    }
}
