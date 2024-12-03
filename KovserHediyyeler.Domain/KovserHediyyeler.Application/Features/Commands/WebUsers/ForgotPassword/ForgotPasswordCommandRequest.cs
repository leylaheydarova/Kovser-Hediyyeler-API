using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ForgotPassword
{
    public class ForgotPasswordCommandRequest : IRequest<ForgotPasswordCommandResponse>
    {
        public string Email { get; set; }
        public string WebUserUri { get; set; }
    }
}
