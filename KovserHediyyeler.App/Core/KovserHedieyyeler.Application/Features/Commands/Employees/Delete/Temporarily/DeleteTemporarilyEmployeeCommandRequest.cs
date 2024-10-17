using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily
{
    public class DeleteTemporarilyEmployeeCommandRequest:DeleteCommandRequest, IRequest<DeleteTemporarilyEmployeeCommandResponse>
    {
    }
}
