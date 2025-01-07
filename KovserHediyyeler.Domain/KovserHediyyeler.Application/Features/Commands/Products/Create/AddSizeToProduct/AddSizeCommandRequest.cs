using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Create.AddSizeToProduct
{
    public class AddSizeCommandRequest : IRequest<AddSizeCommandResponse>
    {
        public string ProductId { get; set; }
        public string SizeName { get; set; }
        public int SizeStock { get; set; }
    }
}
