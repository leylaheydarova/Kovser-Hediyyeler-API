using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployeeAddress
{
    public class RemoveAddressCommandRequest:DeleteCommandRequest, IRequest<RemoveAddressCommandResponse>
    {
    }
}
