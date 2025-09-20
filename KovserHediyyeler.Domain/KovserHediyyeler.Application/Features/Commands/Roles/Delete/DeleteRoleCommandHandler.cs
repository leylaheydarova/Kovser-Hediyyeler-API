using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        readonly IRoleService _service;

        public DeleteRoleCommandHandler(IRoleService service)
        {
            _service = service;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteRole(request.Id.ToString());
            if (!result) throw new FailException();
            return new DeleteRoleCommandResponse
            {
                Message = "Rol uğurla silindi"
            };
        }
    }
}
