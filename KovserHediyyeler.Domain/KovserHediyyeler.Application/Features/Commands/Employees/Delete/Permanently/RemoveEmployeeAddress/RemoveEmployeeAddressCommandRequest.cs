
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress
{
    public class RemoveEmployeeAddressCommandRequest:DeleteCommandRequest, IRequest<RemoveEmployeeAddressCommandResponse>
    {
    }
}
