using KovserHedieyyeler.Application.Features;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WishLists
{
    public class GetWishListQueryRequest : IdRequest, IRequest<GetWishListQueryResponse>
    {
    }
}
