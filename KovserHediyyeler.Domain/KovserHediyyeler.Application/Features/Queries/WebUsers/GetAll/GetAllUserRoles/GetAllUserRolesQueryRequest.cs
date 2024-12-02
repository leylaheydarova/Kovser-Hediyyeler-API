using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserRoles
{
    public class GetAllUserRolesQueryRequest : IRequest<GetAllUserRolesQueryResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
