using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Roles.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleService _service;

        public CreateRoleCommandHandler(IRoleService service)
        {
            _service = service;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateRole(request.RoleName);
            if (!result) throw new FailException("Rol yaranarkən xəta baş verdi!");
            return new CreateRoleCommandResponse
            {
                StatusCode = 201,
                Message = "Rol uğurla yaradılmışdır!"
            };
        }
    }
}
