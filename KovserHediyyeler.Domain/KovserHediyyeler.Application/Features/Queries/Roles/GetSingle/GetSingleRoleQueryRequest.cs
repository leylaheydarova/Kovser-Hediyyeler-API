using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Roles.GetSingle
{
    public class GetSingleRoleQueryRequest : GetSingleQueryRequest, IRequest<GetSingleRoleQueryResponse>
    {
    }
}
