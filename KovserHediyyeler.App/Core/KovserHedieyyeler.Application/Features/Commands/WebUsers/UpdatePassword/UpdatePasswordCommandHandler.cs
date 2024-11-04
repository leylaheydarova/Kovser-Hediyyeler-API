using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeFailedException("Zəhmət olmasa şifrəni hər iki xanaya eyni qeyd edin!");
            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
            return new();
        }
    }
}
