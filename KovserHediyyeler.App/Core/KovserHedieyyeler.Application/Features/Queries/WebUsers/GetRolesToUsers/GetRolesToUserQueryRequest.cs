using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.WebUsers.GetRolesToUsers
{
    public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
    {
        public string? UserIdOrEmail { get; set; }

    }
}
