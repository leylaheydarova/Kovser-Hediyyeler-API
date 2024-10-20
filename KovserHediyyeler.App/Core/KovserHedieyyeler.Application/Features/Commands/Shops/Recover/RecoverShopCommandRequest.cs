
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Recover
{
    public class RecoverShopCommandRequest:RecoverCommandRequest, IRequest<RecoverShopCommandResponse>
    {
    }
}
