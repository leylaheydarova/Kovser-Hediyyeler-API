using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProductShop
{
    public class RemoveProductShopCommandRequest : IRequest<RemoveProductShopCommandResponse>
    {
        public string ProductId { get; set; }
        public string ShoptId { get; set; }
    }
}
