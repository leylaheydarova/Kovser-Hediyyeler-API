using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Accounts;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {

            UserResponse response = await _userService.CreateAsync(request.Dto);

            return new RegisterUserCommandResponse()
            {
                userResponse = response
            };
        }
    }
}
