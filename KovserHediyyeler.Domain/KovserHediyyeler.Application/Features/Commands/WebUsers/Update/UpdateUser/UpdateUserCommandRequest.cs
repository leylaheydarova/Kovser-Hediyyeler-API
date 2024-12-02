using KovserHediyyeler.Application.DTOs.WebUsers;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
        public UserDto Dto { get; set; }
    }
}
