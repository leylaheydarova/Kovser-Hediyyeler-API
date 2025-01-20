using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalPrice
{
    public class GetTotalPriceQueryRequest : IRequest<GetTotalPriceQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
