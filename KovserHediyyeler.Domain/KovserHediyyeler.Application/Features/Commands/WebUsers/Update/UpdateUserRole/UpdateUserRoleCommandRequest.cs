using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUserRole
{
    public class UpdateUserRoleCommandRequest : IRequest<UpdateUserRoleCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
        public string ExistingRole { get; set; }
        public string NewRole { get; set; }
    }
}
