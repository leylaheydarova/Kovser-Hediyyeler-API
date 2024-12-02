using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserRoles
{
    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQueryRequest, GetAllUserRolesQueryResponse>
    {
        readonly IUserService _service;

        public GetAllUserRolesQueryHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<GetAllUserRolesQueryResponse> Handle(GetAllUserRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _service.GetAllUserRolesAsync(request.UserIdOrEmail);
            return new GetAllUserRolesQueryResponse
            {
                Roles = roles
            };
        }
    }
}
