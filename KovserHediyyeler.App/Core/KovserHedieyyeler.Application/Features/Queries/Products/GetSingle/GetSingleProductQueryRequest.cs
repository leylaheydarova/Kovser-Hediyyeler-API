using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle
{
    public class GetSingleProductQueryRequest:GetSingleQueryRequest, IRequest<GetSingleProductQueryResponse>
    {
    }
}
