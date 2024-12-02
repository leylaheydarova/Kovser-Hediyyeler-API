using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WebUsers.GetAll.GetAllUserAddresses
{
    public class GetAllUserAddressesQueryRequest : GetAllQueryRequest, IRequest<GetAllUserAddressesQueryResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
