using KovserHedieyyeler.Application.Features;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.Promotions.GetExpireDate
{
    public class GetPromotionExpireDateQueryRequest : IdRequest, IRequest<GetPromotionExpireDateQueryResponse>
    {
    }
}
