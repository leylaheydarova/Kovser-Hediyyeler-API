using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.WebUsers.GetSingleUser
{
    public class GetSingleUserQueryRequest : IRequest<GetSingleUserQueryResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
