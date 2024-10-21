using KovserHedieyyeler.Application.DTOs.Employees;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest : UpdateCommandRequest<EmployeePutDto>, IRequest<UpdateEmployeeCommandResponse>
    {
    }
}
