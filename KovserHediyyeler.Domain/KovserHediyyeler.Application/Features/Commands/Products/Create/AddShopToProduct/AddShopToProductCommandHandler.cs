using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddShopToProduct
{
    public class AddShopToProductCommandHandler : IRequestHandler<AddShopToProductCommandRequest, AddShopToProductCommandResponse>
    {
        readonly IProductPostService _service;

        public AddShopToProductCommandHandler(IProductPostService service)
        {
            _service = service;
        }

        public async Task<AddShopToProductCommandResponse> Handle(AddShopToProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.AddProductShopAsync(request.ProductId, request.ShopId);
            return new AddShopToProductCommandResponse()
            {
                Message = "Məhsul uğurla mağazaya əlavə edildi!"
            };
        }
    }
}
