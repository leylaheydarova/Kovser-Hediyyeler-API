using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketTotalPrice
{
    public class GetBasketTotalPriceQueryRequest : IRequest<GetBasketTotalPriceQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
