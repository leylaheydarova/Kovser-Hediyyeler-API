using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProducts
{
    public class RemovePermanentlyProductCommandHandler : IRequestHandler<RemovePermanentlyProductCommandRequest, RemovePermanentlyProductCommandResponse>
    {
        readonly IProductDeleteService _service;

        public RemovePermanentlyProductCommandHandler(IProductDeleteService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyProductCommandResponse> Handle(RemovePermanentlyProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyProductAsync(request.Id);
            return new RemovePermanentlyProductCommandResponse
            {
                Message = "Məhsul uğurla silinmişdir!"
            };
        }
    }
}
