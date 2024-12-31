using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Departments.Delete.Permanently.RemoveDepartment
{
    public class RemoveDepartmentCommandRequest : DeleteCommandRequest, IRequest<RemoveDepartmentCommandResponse>
    {
    }
}
