using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProperty
{
    public class RemoveProductPropertyCommandHandler : IRequestHandler<RemoveProductPropertyCommandRequest, RemoveProductPropertyCommandResponse>
    {
        readonly IProductDeleteService _service;

        public RemoveProductPropertyCommandHandler(IProductDeleteService service)
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
