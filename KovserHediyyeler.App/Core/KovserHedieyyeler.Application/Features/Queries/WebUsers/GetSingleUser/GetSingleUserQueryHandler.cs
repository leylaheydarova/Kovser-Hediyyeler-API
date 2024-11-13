using KovserHedieyyeler.Application.Abstractions.Services;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.WebUsers.GetSingleUser
{
    public class GetSingleUserQueryHandler : IRequestHandler<GetSingleUserQueryRequest, GetSingleUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetSingleUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetSingleUserQueryResponse> Handle(GetSingleUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _userService.GetUserAsync(request.UserIdOrEmail);
            return new GetSingleUserQueryResponse
            {
                Dto = dto
            };
        }
    }
}
