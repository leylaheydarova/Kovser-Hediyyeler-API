using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Features.Commands.WebUsers.Add.AddRoleToUser;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Add.AddRolesToUser
{
    public class AddRolesToUserCommandHandler : IRequestHandler<AddRolesToUserCommandRequest, AddRolesToUserCommandResponse>
    {
        readonly IUserService _service;

        public AddRolesToUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<AddRolesToUserCommandResponse> Handle(AddRolesToUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddRolesToUserAsync(request.Email, request.Roles);
            return new AddRolesToUserCommandResponse
            {
                Message = "İstifadəçiyə rol(lar) uğurla əlavə olundu!"
            };
        }
    }
}
