using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Promotions.GetExpireDate
{
    public class GetPromotionExpireDateQueryHandler : IRequestHandler<GetPromotionExpireDateQueryRequest, GetPromotionExpireDateQueryResponse>
    {
        readonly IPromotionService _service;

        public GetPromotionExpireDateQueryHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<GetPromotionExpireDateQueryResponse> Handle(GetPromotionExpireDateQueryRequest request, CancellationToken cancellationToken)
        {
            var expiredate = await _service.GetExpireDateAsync(request.Id);
            return new GetPromotionExpireDateQueryResponse
            {
                ExpireDate = expiredate
            };
        }
    }
}
