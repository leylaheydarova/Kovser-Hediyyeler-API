using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
