using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.AddOrUpdateRole
{
    public class AddOrUpdateUserRoleCommandHandler : IRequestHandler<AddOrUpdateUserRoleCommandRequest, AddOrUpdateUserRoleCommandResponse>
    {
        readonly IUserService _service;

        public AddOrUpdateUserRoleCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<AddOrUpdateUserRoleCommandResponse> Handle(AddOrUpdateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddOrUpdateRoleToUser(request.UserIdOrEmail, request.Roles);
            return new AddOrUpdateUserRoleCommandResponse
            {
                Message = "Məlumatlar uğurla yeniləndi!"
            };
        }
    }
}
