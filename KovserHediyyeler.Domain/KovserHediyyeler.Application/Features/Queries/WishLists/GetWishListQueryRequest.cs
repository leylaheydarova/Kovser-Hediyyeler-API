using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WishLists
{
    public class GetWishListQueryRequest : IRequest<GetWishListQueryResponse>
    {
        public string CustomerId { get; set; }
    }
}
