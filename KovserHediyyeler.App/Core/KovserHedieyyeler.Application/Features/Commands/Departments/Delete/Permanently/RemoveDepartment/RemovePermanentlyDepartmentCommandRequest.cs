using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment
{
    public class RemovePermanentlyDepartmentCommandRequest : DeleteCommandRequest, IRequest<RemovePermanentlyDepartmentCommandResponse>
    {
    }
}
