using KovserHedieyyeler.Application.DTOs.Department;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateDepartment
{
    public class CreateDepartmentCommandRequest : CreateCommandRequest<DepartmentCommandDto>, IRequest<CreateDepartmentCommandResponse>
    {

    }
}
