using KovserHedieyyeler.Application.DTOs.Employees;
using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployee
{
    public class CreateEmployeeCommandRequest : CreateCommandRequest<EmployeePostDto>, IRequest<CreateEmployeeCommandResponse>
    {
    }
}
