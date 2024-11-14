using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Temporarily
{
    public class DeleteTemporarilyDepartmentCommandRequest:DeleteCommandRequest, IRequest<DeleteTemporarilyDepartmentCommandResponse>
    {
    }
}
