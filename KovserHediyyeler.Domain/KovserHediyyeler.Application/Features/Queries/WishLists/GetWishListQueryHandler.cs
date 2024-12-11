using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Queries.WishLists
{
    public class GetWishListQueryHandler : IRequestHandler<GetWishListQueryRequest, GetWishListQueryResponse>
    {
        readonly IWishListService _service;

        public GetWishListQueryHandler(IWishListService service)
        {
            _service = service;
        }

        public async Task<GetWishListQueryResponse> Handle(GetWishListQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetWishListAsync(request.Id);
            return new GetWishListQueryResponse
            {
                Dto = dto
            };
        }
    }
}
