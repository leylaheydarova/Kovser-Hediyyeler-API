using KovserHedieyyeler.Application.DTOs.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShop
{
    public class CreateShopCommandRequest : CreateCommandRequest<ShopPostDto>, IRequest<CreateShopCommandResponse>
    {
    }
}
