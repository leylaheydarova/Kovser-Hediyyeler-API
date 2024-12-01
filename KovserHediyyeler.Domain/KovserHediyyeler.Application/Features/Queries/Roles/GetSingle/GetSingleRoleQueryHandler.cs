using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Roles.GetSingle
{
    public class GetSingleRoleQueryHandler : IRequestHandler<GetSingleRoleQueryRequest, GetSingleRoleQueryResponse>
    {
        readonly IRoleService _service;

        public GetSingleRoleQueryHandler(IRoleService service)
        {
            _service = service;
        }

        public async Task<GetSingleRoleQueryResponse> Handle(GetSingleRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetRoleById(request.Id);
            return new GetSingleRoleQueryResponse
            {
                Dto = dto
            };
        }
    }
}
