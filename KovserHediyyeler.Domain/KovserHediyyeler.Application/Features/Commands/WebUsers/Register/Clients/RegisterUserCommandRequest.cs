using KovserHedieyyeler.Application.Features.Commands;
using KovserHediyyeler.Application.DTOs.WebUsers;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Clients
{
    public class RegisterUserCommandRequest : CreateCommandRequest<RegisterDto>, IRequest<RegisterUserCommandResponse>
    {
    }
}
