using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        readonly IBasketService _service;

        public GetBasketQueryHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetBasketAsync(request.CustomerId);
            return new GetBasketQueryResponse
            {
                Dto = dto
            };
        }
    }
}
