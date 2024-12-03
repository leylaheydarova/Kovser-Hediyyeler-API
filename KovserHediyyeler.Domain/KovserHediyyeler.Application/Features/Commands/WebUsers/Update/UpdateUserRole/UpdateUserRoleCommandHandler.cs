using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest, UpdateUserRoleCommandResponse>
    {
        readonly IUserService _service;

        public UpdateUserRoleCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateUserRoleAsync(request.UserIdOrEmail, request.ExistingRole, request.NewRole);
            return new UpdateUserRoleCommandResponse
            {
                Message = "İstifadəçi rolu uğurla yeniləndi!"
            };
        }
    }
}
