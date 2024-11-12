using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryRequest : GetAllQueryRequest, IRequest<GetRolesQueryResponse>
    {

    }
}