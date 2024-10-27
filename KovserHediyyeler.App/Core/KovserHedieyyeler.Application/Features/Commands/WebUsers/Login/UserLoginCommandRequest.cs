using KovserHedieyyeler.Application.DTOs.Accounts;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public LoginDto Dto { get; set; }
    }
}
