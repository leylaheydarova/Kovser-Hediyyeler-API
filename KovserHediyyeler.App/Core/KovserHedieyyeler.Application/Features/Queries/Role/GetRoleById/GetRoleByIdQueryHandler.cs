using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Roles;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetRoleByIdQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var (id, name) = await _roleService.GetRoleById(request.Id);
            var dto = new RoleGetDto
            {
                Id = id,
                Name = name
            };
            return new GetRoleByIdQueryResponse
            {
                Dto = dto
            };
        }
    }
}
