using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Login
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public UserLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.Dto.Email, request.Dto.Password, 15);
            if (token != null)
            {
                return new UserLoginSuccessCommandResponse()
                {
                    StatusCode = 201,
                    Token = token
                };

            }
            else
            {
                return new UserLoginErrorCommandResponse()
                {
                    StatusCode = 400,
                    Message = "Şifrə və ya email ünvanda yalnışlıq var!"
                };
            }
        }
    }
}
