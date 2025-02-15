using KovserHedieyyeler.Application.DTOs.Positions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.Update
{
    public class UpdatePositionCommandRequest : UpdateCommandRequest<PositionCommandDto>, IRequest<UpdatePositionCommandResponse>
    {
    }
}
