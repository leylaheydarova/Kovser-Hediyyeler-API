using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WishLists.Remove
{
    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommandRequest, RemoveItemCommandResponse>
    {
        readonly IWishListService _service;

        public RemoveItemCommandHandler(IWishListService service)
        {
            _service = service;
        }

        public async Task<RemoveItemCommandResponse> Handle(RemoveItemCommandRequest request, CancellationToken cancellationToken)
        {
            var resultSucceded = await _service.RemoveItemFromWishListAsync(request.Dto.CustomerId, request.Dto.ProductId);
            if (!resultSucceded)
            {
                return new RemoveItemCommandResponse
                {
                    Message = "Məhsul sevilənlər siyahısında yoxdur!"
                };
            }
            return new RemoveItemCommandResponse
            {
                Message = "Məhsul sevilənlər siyahısından uğurla silindi!"
            };
        }
    }
}
