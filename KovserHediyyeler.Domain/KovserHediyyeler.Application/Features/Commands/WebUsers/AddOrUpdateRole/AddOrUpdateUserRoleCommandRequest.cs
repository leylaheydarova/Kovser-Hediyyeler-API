using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.AddOrUpdateRole
{
    public class AddOrUpdateUserRoleCommandRequest : IRequest<AddOrUpdateUserRoleCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
        public string[] Roles { get; set; }
    }
}
