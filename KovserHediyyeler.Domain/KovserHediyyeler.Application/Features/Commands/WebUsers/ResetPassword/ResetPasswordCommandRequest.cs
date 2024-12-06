using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ResetPassword
{
    public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
    {
        public string ResetToken { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
