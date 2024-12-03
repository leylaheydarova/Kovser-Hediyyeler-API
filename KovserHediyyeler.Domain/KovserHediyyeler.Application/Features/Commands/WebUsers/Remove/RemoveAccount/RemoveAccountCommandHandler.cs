using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAccount
{
    public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommandRequest, RemoveAccountCommandResponse>
    {
        readonly IUserService _service;

        public RemoveAccountCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<RemoveAccountCommandResponse> Handle(RemoveAccountCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemoveAccountAsync(request.UserIdOrName);
            return new RemoveAccountCommandResponse()
            {
                Message = "istifadəçi hesabı uğurla silinmişdir!"
            };
        }
    }
}
