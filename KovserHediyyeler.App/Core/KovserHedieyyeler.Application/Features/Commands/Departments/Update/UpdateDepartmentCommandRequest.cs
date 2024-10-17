using KovserHedieyyeler.Application.DTOs.Department;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update
{
    public class UpdateDepartmentCommandRequest:UpdateCommandRequest<DepartmentCommandDto>, IRequest<UpdateDepartmentCommandResponse>
    {
        public string? Nickname { get; set; }
    }
}
