using MediatR;
namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployee
{
    public class RemovePermanentlyEmployeeCommandRequest : DeleteCommandRequest, IRequest<RemovePermanentlyEmployeeCommandResponse>
    {
    }
}
