using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ResetPassword
{
    public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
    {
        public string? Email { get; set; }
        public string NewPassword { get; set; }
    }
}
