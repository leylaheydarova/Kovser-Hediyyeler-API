using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Register.Clients
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        readonly IUserService _service;

        public RegisterUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateUserAsync(request.Dto);
            if (!result.isSucceeded) throw new RegisterFailedException();
            return new RegisterUserCommandResponse
            {
                StatusCode = 201,
                Message = result.Message
            };
        }
    }
}
