using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Positions.Update.Recover
{
    public class RecoverPositionCommandRequest : RecoverCommandRequest, IRequest<RecoverPositionCommandResponse>
    {
    }
}
