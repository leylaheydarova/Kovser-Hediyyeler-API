using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetAll.OrderDetails
{
    public class GetAllOrderDetailsQueryRequest:IRequest<GetAllOrderDetailsQueryResponse>
    {
        public Guid OrderId { get; set; }
    }
}
