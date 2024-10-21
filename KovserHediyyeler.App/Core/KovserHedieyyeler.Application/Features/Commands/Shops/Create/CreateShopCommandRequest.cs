using KovserHedieyyeler.Application.DTOs.Shops;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create
{
    public class CreateShopCommandRequest:CreateCommandRequest<ShopPostDto>, IRequest<CreateShopCommandResponse>
    {
    }
}
