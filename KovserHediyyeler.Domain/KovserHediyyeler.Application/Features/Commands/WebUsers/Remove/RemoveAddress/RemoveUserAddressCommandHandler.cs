using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Remove.RemoveAddress
{
    public class RemoveUserAddressCommandHandler : IRequestHandler<RemoveUserAddressCommandRequest, RemoveUserAddressCommandResponse>
    {
        readonly IUserService _service;

        public RemoveUserAddressCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<RemoveUserAddressCommandResponse> Handle(RemoveUserAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemoveUserAddressAsync(request.UserIdOrEmail, request.Id);
            return new RemoveUserAddressCommandResponse
            {
                Message = "İstifadəçi ünvanı uğurla silinmişdir!"
            };
        }
    }
}
