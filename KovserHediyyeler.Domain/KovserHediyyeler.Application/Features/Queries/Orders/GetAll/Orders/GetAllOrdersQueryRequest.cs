using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetAll.Orders
{
    public class GetAllOrdersQueryRequest : GetAllQueryRequest, IRequest<GetAllOrdersQueryResponse>
    {
    }
}
