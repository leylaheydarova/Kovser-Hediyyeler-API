using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Moderators
{
    public class RegisterModeratorCommandHandler : IRequestHandler<RegisterModeratorCommandRequest, RegisterModeratorCommandResponse>
    {
        readonly IUserService _service;

        public RegisterModeratorCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<RegisterModeratorCommandResponse> Handle(RegisterModeratorCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateModeratorAsync(request.Dto, request.RoleName);
            if (!result.isSucceeded) throw new RegisterFailedException();
            return new RegisterModeratorCommandResponse
            {
                StatusCode = 201,
                Message = result.Message
            };
        }
    }
}
