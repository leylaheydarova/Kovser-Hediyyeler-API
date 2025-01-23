using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress
{
    public class UpdateShopAddressCommandHandler : IRequestHandler<UpdateShopAddressCommandRequest, UpdateShopAddressCommandResponse>
    {
        readonly IShopService _service;

        public UpdateShopAddressCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<UpdateShopAddressCommandResponse> Handle(UpdateShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateShopAddressAsync(request.Dto, request.Id, request.ShopId);

            return new UpdateShopAddressCommandResponse
            {
                Message = "Mağaza ünvanı uğurla dəyişdirildi!"
            };
        }
    }
}


