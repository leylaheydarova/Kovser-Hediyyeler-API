using KovserHedieyyeler.Application.DTOs.Employees;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update
{
    public class UpdateEmployeeCommandRequest:UpdateCommandRequest<EmployeeCommandDto>, IRequest<UpdateEmployeeCommandResponse>
    {
    }
}
