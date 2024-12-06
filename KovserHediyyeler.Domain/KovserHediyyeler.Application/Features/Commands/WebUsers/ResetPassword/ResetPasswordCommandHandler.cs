using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
    {
        readonly IUserService _service;

        public ResetPasswordCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.ResetPasswordAsync(request.ResetToken, request.Email!, request.NewPassword, request.ConfirmPassword);
            return new ResetPasswordCommandResponse
            {
                Message = "Şifrə uğurla dəyişdirildi!"
            };
        }
    }
}
