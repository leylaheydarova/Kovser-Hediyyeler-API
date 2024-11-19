using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddShopToProduct
{
    public class AddShopToProductCommandRequest : IRequest<AddShopToProductCommandResponse>
    {
        public string ProductId { get; set; }
        public string ShopId { get; set; }
    }
}
