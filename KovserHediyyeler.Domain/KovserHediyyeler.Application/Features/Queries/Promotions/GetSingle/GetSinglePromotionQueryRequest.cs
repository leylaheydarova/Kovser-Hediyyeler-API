using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetSingle
{
    public class GetSinglePromotionQueryRequest:GetSingleQueryRequest, IRequest<GetSinglePromotionQueryResponse>
    {
    }
}
