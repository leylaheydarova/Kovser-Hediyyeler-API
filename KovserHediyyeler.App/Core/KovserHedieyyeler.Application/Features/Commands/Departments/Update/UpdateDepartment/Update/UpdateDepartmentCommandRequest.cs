using KovserHedieyyeler.Application.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.Update
{
    public class UpdateDepartmentCommandRequest : UpdateCommandRequest<DepartmentUpdateDto>, IRequest<UpdateDepartmentCommandResponse>
    {
    }
}
