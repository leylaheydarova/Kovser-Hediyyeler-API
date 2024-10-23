using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.WebUsers.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        public Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
