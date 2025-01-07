using KovserHedieyyeler.Application.Features.Queries;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Orders.GetSingle.Order
{
    public class GetSingleOrderQueryRequest:GetSingleQueryRequest, IRequest<GetSingleOrderQueryResponse>
    {
    }
}
