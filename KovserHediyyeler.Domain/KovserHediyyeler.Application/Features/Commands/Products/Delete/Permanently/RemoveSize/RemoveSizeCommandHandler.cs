using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveSize
{
    public class RemoveSizeCommandHandler : IRequestHandler<RemoveSizeCommandRequest, RemoveSizeCommandResponse>
    {
        readonly IProductService _service;

        public RemoveSizeCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<RemoveSizeCommandResponse> Handle(RemoveSizeCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyProductSizeAsync(request.Id);
            return new RemoveSizeCommandResponse
            {
                Message = "Ölçü uğurla silnimişdir!"
            };
        }
    }
}
