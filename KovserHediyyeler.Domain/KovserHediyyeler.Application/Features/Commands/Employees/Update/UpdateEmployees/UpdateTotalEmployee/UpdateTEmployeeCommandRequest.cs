using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateTotalEmployee
{
    public class UpdateTEmployeeCommandRequest : UpdateCommandRequest<EmployeePutDto>, IRequest<UpdateTEmployeeCommandResponse>
    {
    }
}
