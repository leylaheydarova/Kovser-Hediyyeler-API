using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetAll.CustomerOrders
{
    public class GetAllCustomerOrdersQueryRequest : GetAllQueryRequest, IRequest<GetAllCustomerOrdersQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
