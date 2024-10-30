using KovserHedieyyeler.Application.Abstractions.Services;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Login
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
            var token = await _authService.LoginAsync(request.Dto.Email, request.Dto.Password, 900);
            if(token != null)
            {
                return new UserLoginSuccessCommandResponse()
                {
                    Token = token
                };

            }
            else
            {
                return new UserLoginErrorCommandResponse()
                {
                    Message = "Şifrə və ya email ünvanda yalnışlıq var!"
                };
            }
        }
    }
}
