
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Recover
{
    public class RecoverEmployeeCommandHandler : IRequestHandler<RecoverEmployeeCommandRequest, RecoverEmployeeCommandResponse>
    {
        public Task<RecoverEmployeeCommandResponse> Handle(RecoverEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
