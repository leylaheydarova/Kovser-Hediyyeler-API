using KovserHedieyyeler.Application.Features.Commands;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ForgotPassword
{
    public class ForgotPasswordCommandResponse : CommandResponse
    {
        public string Token { get; set; }
    }
}
