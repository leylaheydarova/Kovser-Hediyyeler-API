using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll.GetAllShops
{
    public class GetAllShopsQueryRequest : GetAllQueryRequest, IRequest<GetAllShopsQueryResponse>
    {
    }
}
