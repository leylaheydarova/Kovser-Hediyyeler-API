
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductProperty
{
    public class GetSingleProductPropertyQueryRequest:GetSingleQueryRequest, IRequest<GetSingleProductPropertyQueryResponse>
    {
    }
}
