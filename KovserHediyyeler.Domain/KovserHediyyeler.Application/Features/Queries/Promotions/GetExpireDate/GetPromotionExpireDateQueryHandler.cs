using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Promotions.GetExpireDate
{
    public class GetPromotionExpireDateQueryHandler : IRequestHandler<GetPromotionExpireDateQueryRequest, GetPromotionExpireDateQueryResponse>
    {
        readonly IPromotionReadRepository _repository;

        public GetPromotionExpireDateQueryHandler(IPromotionReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPromotionExpireDateQueryResponse> Handle(GetPromotionExpireDateQueryRequest request, CancellationToken cancellationToken)
        {
            Promotion promotion = await _repository.GetWhereAsync(p => p.ID.ToString() == request.Id && !p.isDeleted, false);
            if (promotion == null) throw new PromotionNotFoundException();
            return new GetPromotionExpireDateQueryResponse
            {
                ExpireDate = promotion.ExpireDate
            };
        }
    }
}
