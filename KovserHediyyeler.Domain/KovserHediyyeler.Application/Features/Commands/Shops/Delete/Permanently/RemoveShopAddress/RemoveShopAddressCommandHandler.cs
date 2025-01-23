using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress
{
    public class RemoveShopAddressCommandHandler : IRequestHandler<RemoveShopAddressCommandRequest, RemoveShopAddressCommandResponse>
    {
        readonly IShopService _service;

        public RemoveShopAddressCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<RemoveShopAddressCommandResponse> Handle(RemoveShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyShopAddressAsync(request.Id);
            return new RemoveShopAddressCommandResponse
            {
                Message = "Mağaza ünvanı uğurla silinmişdir"
            };
        }
    }
}
