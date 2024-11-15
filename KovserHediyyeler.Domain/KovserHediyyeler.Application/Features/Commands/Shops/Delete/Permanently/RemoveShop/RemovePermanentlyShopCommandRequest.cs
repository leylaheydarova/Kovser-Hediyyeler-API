using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShop
{
    public class RemovePermanentlyShopCommandRequest : DeleteCommandRequest, IRequest<RemovePermanentlyShopCommandResponse>
    {
    }
}
