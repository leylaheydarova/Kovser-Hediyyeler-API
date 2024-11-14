using KovserHedieyyeler.Application.DTOs.Department;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal
{
    public class UpdateTotalDepartmentCommandRequest : UpdateCommandRequest<DepartmentCommandDto>, IRequest<UpdateTotalDepartmentCommandResponse>
    {
        public string? Nickname { get; set; }
    }
}
