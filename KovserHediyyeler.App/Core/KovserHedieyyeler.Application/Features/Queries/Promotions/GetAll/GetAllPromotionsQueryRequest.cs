using MediatR;


namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetAll
{
    public class GetAllPromotionsQueryRequest:GetAllQueryRequest, IRequest<GetAllPromotionsQueryResponse>
    {
    }
}
