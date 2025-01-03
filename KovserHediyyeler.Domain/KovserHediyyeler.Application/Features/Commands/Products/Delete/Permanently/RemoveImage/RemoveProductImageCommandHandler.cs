using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductDeleteService _service;

        public RemoveProductImageCommandHandler(IProductDeleteService service)
        {
            _service = service;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyProductImageFileAsync(request.Id);

            return new RemoveProductImageCommandResponse
            {
                Message = "Məhsul şəkli uğurl silinmişdir!"
            };
        }
    }
}
