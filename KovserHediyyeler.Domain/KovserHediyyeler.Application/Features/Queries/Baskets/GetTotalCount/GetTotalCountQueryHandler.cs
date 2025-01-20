using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalCount
{
    public class GetTotalCountQueryHandler : IRequestHandler<GetTotalCountQueryRequest, GetTotalCountQueryResponse>
    {
        readonly IBasketService _service;

        public GetTotalCountQueryHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<GetTotalCountQueryResponse> Handle(GetTotalCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await _service.GetTotalItemCountAsync(request.CustomerId);
            return new GetTotalCountQueryResponse
            {
                TotalCount = count
            };
        }
    }
}
