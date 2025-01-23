using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShop
{
    public class CreateShopCommandHandler : IRequestHandler<CreateShopCommandRequest, CreateShopCommandResponse>
    {
        readonly IShopService _service;

        public CreateShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<CreateShopCommandResponse> Handle(CreateShopCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.CreateShopAsync(request.Dto);

            return new CreateShopCommandResponse
            {
                StatusCode = 201,
                Message = "Mağaza uğurla əlavə edilmişdir!"
            };
        }
    }
}
