using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Recover
{
    public class RecoverProductCommandHandler : IRequestHandler<RecoverProductCommandRequest, RecoverProductCommandResponse>
    {
        readonly IProductService _service;

        public RecoverProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<RecoverProductCommandResponse> Handle(RecoverProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverProductDataAsync(request.Id);
            return new RecoverProductCommandResponse
            {
                Message = "Məhsul məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
