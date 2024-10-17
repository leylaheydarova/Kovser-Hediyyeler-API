using KovserHedieyyeler.Application.DTOs.Employees;
using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create
{
    public class CreateEmployeeCommandRequest:CreateCommandRequest<EmployeeCommandDto>, IRequest<CreateEmployeeCommandResponse>
    {
    }
}
