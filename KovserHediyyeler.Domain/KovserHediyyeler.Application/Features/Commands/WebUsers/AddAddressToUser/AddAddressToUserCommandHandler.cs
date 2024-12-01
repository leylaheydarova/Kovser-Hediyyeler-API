using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.AddAddressToUser
{
    public class AddAddressToUserCommandHandler : IRequestHandler<AddAddressToUserCommandRequest, AddAddressToUserCommandResponse>
    {
        readonly IUserService _service;

        public AddAddressToUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<AddAddressToUserCommandResponse> Handle(AddAddressToUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddAddressToUserAsync(request.UserIdOrEmail, request.Dto);
            return new AddAddressToUserCommandResponse
            {
                StatusCode = 201,
                Message = "İstifadəçi ünvanı uğurla əlavə edildi!"
            };
        }
    }
}
