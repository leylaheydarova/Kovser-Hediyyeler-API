using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShop
{
    public class RemovePermanentlyShopCommandHandler : IRequestHandler<RemovePermanentlyShopCommandRequest, RemovePermanentlyShopCommandResponse>
    {
        readonly IShopService _service;

        public RemovePermanentlyShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyShopCommandResponse> Handle(RemovePermanentlyShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyShopAsync(request.Id);

            return new RemovePermanentlyShopCommandResponse
            {
                Message = "Mağaza uğurla silinmişdir"
            };
        }
    }
}
