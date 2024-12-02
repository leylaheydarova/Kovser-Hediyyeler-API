using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUsers
{
    public class GetAllUsersQueryRequest : GetAllQueryRequest, IRequest<GetAllUsersQueryResponse>
    {
    }
}
