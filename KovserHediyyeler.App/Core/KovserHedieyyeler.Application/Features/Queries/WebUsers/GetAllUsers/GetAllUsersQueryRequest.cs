using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.WebUsers.GetAllUsers
{
    public class GetAllUsersQueryRequest : GetAllQueryRequest, IRequest<GetAllUsersQueryResponse>
    {
    }
}
