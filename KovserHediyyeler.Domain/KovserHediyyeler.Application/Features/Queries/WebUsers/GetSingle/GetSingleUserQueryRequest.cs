using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetSingle
{
    public class GetSingleUserQueryRequest : IRequest<GetSingleUserQueryResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
