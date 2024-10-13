using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle
{
    public class GetSingleEmployeeQueryRequest:GetSingleQueryRequest, IRequest<GetSingleEmployeeQueryResponse>
    {
    }
}
