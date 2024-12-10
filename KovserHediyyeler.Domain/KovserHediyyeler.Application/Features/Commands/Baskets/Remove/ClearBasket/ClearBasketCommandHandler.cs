using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Remove.ClearBasket
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommandRequest, ClearBasketCommandResponse>
    {
        readonly IBasketService _service;

        public ClearBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<ClearBasketCommandResponse> Handle(ClearBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.ClearBasketAsync(request.CustomerId);
            if (result)
            {
                return new ClearBasketCommandResponse
                {
                    Message = "Səbət təmizləndi!"
                };
            }
            else
            {
                return new ClearBasketCommandResponse
                {
                    Message = "Səbət boşdur!"
                };
            }

        }
    }
}
