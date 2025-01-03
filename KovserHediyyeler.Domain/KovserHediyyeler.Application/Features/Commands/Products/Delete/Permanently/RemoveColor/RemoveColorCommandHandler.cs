using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveColor
{
    public class RemoveColorCommandHandler : IRequestHandler<RemoveColorCommandRequest, RemoveColorCommandResponse>
    {
        readonly IProductDeleteService _service;

        public RemoveColorCommandHandler(IProductDeleteService service)
        {
            _service = service;
        }

        public async Task<RemoveColorCommandResponse> Handle(RemoveColorCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyProductColorAsync(request.Id);
            return new RemoveColorCommandResponse
            {
                Message = "Rəng uğurla silinmişdir!"
            };
        }
    }
}
