using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.Update
{
    public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommandRequest, UpdateShopCommandResponse>
    {
        readonly IShopService _service;

        public UpdateShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<UpdateShopCommandResponse> Handle(UpdateShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateShopAsync(request.Dto, request.Id);

            return new UpdateShopCommandResponse
            {
                Message = "Mağaza məlumatları uğurla yeniləndi"
            };

        }
    }
}
