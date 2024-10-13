using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetAll
{
    public class GetAllPositionsQueryRequest:GetAllQueryRequest, IRequest<GetAllPositionsQueryResponse>
    {
    }
}
