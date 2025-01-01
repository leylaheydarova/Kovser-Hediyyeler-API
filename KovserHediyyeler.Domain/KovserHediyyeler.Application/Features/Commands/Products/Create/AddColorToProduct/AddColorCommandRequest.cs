using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddColorToProduct
{
    public class AddColorCommandRequest : IRequest<AddColorCommandResponse>
    {
        public string ProductId { get; set; }
        public string ColorName { get; set; }
    }
}
