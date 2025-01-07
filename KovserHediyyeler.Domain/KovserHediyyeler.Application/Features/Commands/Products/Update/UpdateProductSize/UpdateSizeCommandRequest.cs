using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.UpdateProductSize
{
    public class UpdateSizeCommandRequest : IRequest<UpdateSizeCommandResponse>
    {
        public string ID { get; set; }
        public string? SizeName { get; set; }
        public int SizeStock { get; set; }
    }
}
