using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Update.Recover
{
    public class RecoverEmployeeCommandRequest : RecoverCommandRequest, IRequest<RecoverEmployeeCommandResponse>
    {
    }
}
