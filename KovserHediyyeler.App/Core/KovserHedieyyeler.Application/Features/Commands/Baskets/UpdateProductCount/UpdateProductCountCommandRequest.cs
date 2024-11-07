using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.UpdateProductCount
{
    public class UpdateProductCountCommandRequest:IRequest<UpdateProductCountCommandResponse>
    {
        public Guid ProductId { get; set; }
        public int NewCount { get; set; }
        public string CustomerId { get; set; }
    }
}
