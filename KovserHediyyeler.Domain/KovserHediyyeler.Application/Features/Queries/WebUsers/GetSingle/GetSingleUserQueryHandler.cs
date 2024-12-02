using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetSingle
{
    public class GetSingleUserQueryHandler : IRequestHandler<GetSingleUserQueryRequest, GetSingleUserQueryResponse>
    {
        readonly IUserService _service;

        public GetSingleUserQueryHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<GetSingleUserQueryResponse> Handle(GetSingleUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetUserAsync(request.UserIdOrEmail);
            return new GetSingleUserQueryResponse
            {
                Dto = dto
            };
        }
    }
}
