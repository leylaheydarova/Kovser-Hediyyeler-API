using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalCount
{
    public class GetTotalCountQueryRequest : IRequest<GetTotalCountQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
