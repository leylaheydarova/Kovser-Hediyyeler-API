using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.CreateRole(request.Name);
            if (result == false) throw new BadRequestException();
            return new CreateRoleCommandResponse
            {
                StatusCode = 201,
                Message = "Rol uğurla yaradılmışdır!"
            };
        }
    }
}
