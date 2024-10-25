using KovserHedieyyeler.Application.DTOs.Accounts;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Register
{
    public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
    {
        public RegisterDto Dto { get; set; }
    }
}
