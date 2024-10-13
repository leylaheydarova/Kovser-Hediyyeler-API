using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetSingle
{
    public class GetSingleShopQueryRequest:GetSingleQueryRequest, IRequest<GetSingleShopQueryResponse>
    {
    }
}
