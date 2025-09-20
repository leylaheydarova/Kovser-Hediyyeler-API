using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddColorToProduct
{
    public class AddColorCommandRequest : IRequest<AddColorCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string ColorName { get; set; }
        public int ColorStock { get; set; }
    }
}
