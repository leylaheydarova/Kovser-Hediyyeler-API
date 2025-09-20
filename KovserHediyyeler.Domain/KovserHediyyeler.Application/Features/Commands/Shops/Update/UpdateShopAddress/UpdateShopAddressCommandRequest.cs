using KovserHedieyyeler.Application.DTOs.Addresses;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress
{
    public class UpdateShopAddressCommandRequest : UpdateCommandRequest<AddressUpdateDto>, IRequest<UpdateShopAddressCommandResponse>
    {
        public Guid ShopId { get; set; }
    }
}
