using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketCount
{
    public class GetBasketCountQueryRequest : IRequest<GetBasketCountQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
