using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddShopToProduct
{
    public class AddShopToProductCommandRequest : IRequest<AddShopToProductCommandResponse>
    {
        public Guid ProductId { get; set; }
        public Guid ShopId { get; set; }
    }
}
