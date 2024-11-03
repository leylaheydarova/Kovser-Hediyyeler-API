using KovserHedieyyeler.Application.DTOs.Employees;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee
{
    public class UpdateTotalEmployeeCommandRequest : UpdateCommandRequest<EmployeePutDto>, IRequest<UpdateTotalEmployeeCommandResponse>
    {
    }
}
