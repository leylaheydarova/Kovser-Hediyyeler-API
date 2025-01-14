using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Shops.Update.Recover
{
    public class RecoverShopCommandRequest : RecoverCommandRequest, IRequest<RecoverShopCommandResponse>
    {
    }
}
