using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasket
{
    public class GetBasketQueryRequest : IRequest<GetBasketQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
