using KovserHedieyyeler.Application.DTOs.Positions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.UpdateTotalPosition
{
    public class UpdateTotalPositionCommandRequest : UpdateCommandRequest<PositionCommandDto>, IRequest<UpdateTotalPositionCommandResponse>
    {
    }
}
