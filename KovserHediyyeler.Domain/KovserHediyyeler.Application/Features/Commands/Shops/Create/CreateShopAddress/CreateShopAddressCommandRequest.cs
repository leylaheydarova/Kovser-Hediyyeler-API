using KovserHedieyyeler.Application.DTOs.Addresses;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress
{
    public class CreateShopAddressCommandRequest : CreateCommandRequest<AddressCommandDto>, IRequest<CreateShopAddressCommandResponse>
    {
        public Guid ShopId { get; set; }
    }
}
