using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Create
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public string RoleName { get; set; }
    }
}
