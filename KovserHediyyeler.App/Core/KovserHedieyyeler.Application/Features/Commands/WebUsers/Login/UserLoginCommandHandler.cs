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
            throw new NotImplementedException();
            //var token = await _authService.LoginAsync(request.Dto.Email, request.Dto.Password, 900);
            //return new UserLoginSuccessCommandResponse()
            //{
            //    Token = token
            //};
        }
    }
}
