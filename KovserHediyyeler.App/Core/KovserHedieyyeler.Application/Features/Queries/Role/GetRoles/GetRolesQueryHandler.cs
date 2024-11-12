using KovserHedieyyeler.Application.Abstractions.Services;
using MediatR;
namespace KovserHedieyyeler.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var (datas, totalCount) = await _roleService.GetAllRolesAsync(request.Page, request.Size);



            return new GetRolesQueryResponse
            {
                Datas = datas,
                TotalCount = totalCount
            };
        }
    }
}
