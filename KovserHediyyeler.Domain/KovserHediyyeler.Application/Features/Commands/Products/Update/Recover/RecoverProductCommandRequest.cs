using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.Recover
{
    public class RecoverProductCommandRequest : RecoverCommandRequest, IRequest<RecoverProductCommandResponse>
    {
    }
}
