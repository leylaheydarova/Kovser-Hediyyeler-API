using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently
{
    public class RemovePermanentlyEmployeeCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyEmployeeCommandResponse>
    {
    }
}
