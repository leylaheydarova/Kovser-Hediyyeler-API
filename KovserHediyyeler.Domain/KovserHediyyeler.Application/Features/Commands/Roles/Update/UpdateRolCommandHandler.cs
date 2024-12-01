using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Update
{
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommandRequest, UpdateRolCommandResponse>
    {
        readonly IRoleService _service;

        public UpdateRolCommandHandler(IRoleService service)
        {
            _service = service;
        }

        public async Task<UpdateRolCommandResponse> Handle(UpdateRolCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateRole(request.Id, request.Name);
            if (!result) throw new FailException();
            return new UpdateRolCommandResponse
            {
                Message = "Rol uğurla yeniləndi"
            };
        }
    }
}
