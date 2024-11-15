using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetSingle
{
    public class GetSinglePositionQueryRequest:GetSingleQueryRequest, IRequest<GetSinglePositionQueryResponse>
    {
    }
}
