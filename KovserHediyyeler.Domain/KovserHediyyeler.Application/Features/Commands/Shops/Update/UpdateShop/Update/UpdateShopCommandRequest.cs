using KovserHedieyyeler.Application.DTOs.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.Update
{
    public class UpdateShopCommandRequest : UpdateCommandRequest<ShopPatchDto>, IRequest<UpdateShopCommandResponse>
    {
    }
}
