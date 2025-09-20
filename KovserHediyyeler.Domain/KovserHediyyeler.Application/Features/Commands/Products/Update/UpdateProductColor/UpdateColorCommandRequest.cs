using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductColor
{
    public class UpdateColorCommandRequest : IRequest<UpdateColorCommandResponse>
    {
        public Guid ID { get; set; }
        public string? ColorName { get; set; }
        public int ColorStock { get; set; }
    }
}
