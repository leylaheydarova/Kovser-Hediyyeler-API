using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Shops.GetAll
{
    public class GetAllShopsQueryRequest:GetAllQueryRequest, IRequest<GetAllShopsQueryResponse>
    {
    }
}
