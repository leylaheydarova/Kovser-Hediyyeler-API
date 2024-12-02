using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommandRequest, UpdateUserAddressCommandResponse>
    {
        readonly IUserService _service;

        public UpdateUserAddressCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UpdateUserAddressCommandResponse> Handle(UpdateUserAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateUserAddressAsync(request.UserIdOrEmail, request.Id, request.Dto);
            return new UpdateUserAddressCommandResponse
            {
                Message = "İstifadəçi ünvanı uğurla yeniləndi!"
            };
        }
    }
}
