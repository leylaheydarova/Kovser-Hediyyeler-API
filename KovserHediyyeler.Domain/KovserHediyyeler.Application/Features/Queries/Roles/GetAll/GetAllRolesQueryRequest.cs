using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Roles.GetAll
{
    public class GetAllRolesQueryRequest : GetAllQueryRequest, IRequest<GetAllRolesQueryResponse>
    {
    }
}
