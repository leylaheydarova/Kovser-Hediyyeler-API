using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress
{
    public class CreateShopAddressCommandHandler : IRequestHandler<CreateShopAddressCommandRequest, CreateShopAddressCommandResponse>
    {
        readonly IShopService _service;

        public CreateShopAddressCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<CreateShopAddressCommandResponse> Handle(CreateShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateShopAddressAsync(request.Dto, request.ShopId);

            return new CreateShopAddressCommandResponse
            {
                StatusCode = 201,
                Message = "Mağaza ünvanı uğurla əlavə edilmişdir!"
            };
        }
    }
}
