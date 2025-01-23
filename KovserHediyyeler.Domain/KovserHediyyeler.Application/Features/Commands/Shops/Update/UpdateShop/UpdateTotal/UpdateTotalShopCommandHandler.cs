using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.UpdateTotal
{
    public class UpdateTotalShopCommandHandler : IRequestHandler<UpdateTotalShopCommandRequest, UpdateTotalShopCommandResponse>
    {
        readonly IShopService _service;

        public UpdateTotalShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<UpdateTotalShopCommandResponse> Handle(UpdateTotalShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateTotalShopAsync(request.Dto, request.Id);

            return new UpdateTotalShopCommandResponse
            {
                Message = "Mağaza məlumatları uğurla yeniləndi"
            };
        }
    }
}
