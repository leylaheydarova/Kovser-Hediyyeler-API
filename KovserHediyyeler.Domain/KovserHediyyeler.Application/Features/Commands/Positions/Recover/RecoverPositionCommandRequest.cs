
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Recover
{
    public class RecoverPositionCommandRequest:RecoverCommandRequest, IRequest<RecoverPositionCommandResponse>
    {
    }
}
