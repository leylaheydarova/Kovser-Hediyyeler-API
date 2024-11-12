using KovserHedieyyeler.Application.DTOs.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShop.UpdateTotal
{
    public class UpdateTotalShopCommandRequest : UpdateCommandRequest<ShopPutDto>, IRequest<UpdateTotalShopCommandResponse>
    {
    }
}
