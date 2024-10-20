
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently
{
    public class RemovePermanentlyShopCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyShopCommandResponse>
    {
    }
}
