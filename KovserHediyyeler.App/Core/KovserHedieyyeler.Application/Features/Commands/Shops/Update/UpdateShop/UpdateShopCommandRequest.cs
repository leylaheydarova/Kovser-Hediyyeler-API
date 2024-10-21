using KovserHedieyyeler.Application.DTOs.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.Shop
{
    public class UpdateShopCommandRequest : UpdateCommandRequest<ShopPutDto>, IRequest<UpdateShopCommandResponse>
    {
    }
}
