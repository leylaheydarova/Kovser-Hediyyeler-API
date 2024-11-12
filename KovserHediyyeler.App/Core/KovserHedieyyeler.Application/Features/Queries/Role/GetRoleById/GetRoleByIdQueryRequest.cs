using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryRequest : GetSingleQueryRequest, IRequest<GetRoleByIdQueryResponse>
    {

    }
}