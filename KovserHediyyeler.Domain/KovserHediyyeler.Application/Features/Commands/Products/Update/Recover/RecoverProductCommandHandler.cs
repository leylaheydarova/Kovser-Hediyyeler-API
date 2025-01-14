using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Products.Update.Recover
{
    public class RecoverProductCommandHandler : IRequestHandler<RecoverProductCommandRequest, RecoverProductCommandResponse>
    {
        readonly IProductDeleteService _service;

        public RecoverProductCommandHandler(IProductDeleteService service)
        {
            _service = service;
        }

        public async Task<RecoverProductCommandResponse> Handle(RecoverProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverProductDataAsync(request.Id);
            return new RecoverProductCommandResponse
            {
                Message = "Silinmiş məlumat uğurla bərpa oldu!"
            };
        }
    }
}
