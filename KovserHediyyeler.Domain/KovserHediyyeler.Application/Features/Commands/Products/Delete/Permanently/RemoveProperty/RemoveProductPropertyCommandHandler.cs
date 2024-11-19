using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProperty
{
    public class RemoveProductPropertyCommandHandler : IRequestHandler<RemoveProductPropertyCommandRequest, RemoveProductPropertyCommandResponse>
    {
        readonly IProductService _service;

        public RemoveProductPropertyCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<RemoveProductPropertyCommandResponse> Handle(RemoveProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.RemovePermanentlyProductPropertyAsync(request.Id);
            return new RemoveProductPropertyCommandResponse
            {
                Message = "Məhsul xassəsi uğurla silinmişdir!"
            };
        }

    }
}
