using KovserHedieyyeler.Application.Features.Commands;
using KovserHediyyeler.Application.DTOs.WebUsers;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Moderators
{
    public class RegisterModeratorCommandRequest : CreateCommandRequest<ModeratorDto>, IRequest<RegisterModeratorCommandResponse>
    {
        public string RoleName { get; set; }
    }
}
