
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Recover
{
    public class RecoverEmployeeCommandRequest:RecoverCommandRequest, IRequest<RecoverEmployeeCommandResponse>
    {
    }
}
