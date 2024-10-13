using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetAll
{
    public class GetAllPositionsQueryRequest:GetAllQueryRequest, IRequest<GetAllPositionsQueryResponse>
    {
    }
}
