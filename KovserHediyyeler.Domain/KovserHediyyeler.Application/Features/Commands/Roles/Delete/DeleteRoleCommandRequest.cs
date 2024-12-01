using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Delete
{
    public class DeleteRoleCommandRequest : DeleteCommandRequest, IRequest<DeleteRoleCommandResponse>
    {
    }
}
