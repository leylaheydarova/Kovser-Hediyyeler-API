using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalPrice
{
    public class GetTotalPriceQueryHandler : IRequestHandler<GetTotalPriceQueryRequest, GetTotalPriceQueryResponse>
    {
        readonly IBasketService _service;

        public GetTotalPriceQueryHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<GetTotalPriceQueryResponse> Handle(GetTotalPriceQueryRequest request, CancellationToken cancellationToken)
        {
            var price = await _service.GetTotalPriceAsync(request.CustomerId);
            return new GetTotalPriceQueryResponse
            {
                TotalPrice = price
            };
        }
    }
}
