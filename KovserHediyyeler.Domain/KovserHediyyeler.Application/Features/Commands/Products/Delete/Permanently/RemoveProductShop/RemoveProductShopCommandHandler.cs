using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProductShop
{
    public class RemoveProductShopCommandHandler : IRequestHandler<RemoveProductShopCommandRequest, RemoveProductShopCommandResponse>
    {
        readonly IProductService _service;

        public RemoveProductShopCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<RemoveProductShopCommandResponse> Handle(RemoveProductShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyProductShopAsync(request.ProductId, request.ShoptId);
            return new RemoveProductShopCommandResponse()
            {
                Message = "Məhsul uğurla mağazadan silinmişdir!"
            };
        }
    }
}
