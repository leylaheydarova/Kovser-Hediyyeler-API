using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProductShop
{
    public class RemoveProductShopCommandRequest : IRequest<RemoveProductShopCommandResponse>
    {
        public Guid ProductId { get; set; }
        public Guid ShoptId { get; set; }
    }
}
