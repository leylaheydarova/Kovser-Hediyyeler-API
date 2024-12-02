using KovserHediyyeler.Application.DTOs.WebUsers;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public LoginDto Dto { get; set; }
    }
}
