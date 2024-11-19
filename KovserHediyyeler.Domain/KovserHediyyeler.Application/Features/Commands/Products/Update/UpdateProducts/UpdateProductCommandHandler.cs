using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProducts
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductService _service;

        public UpdateProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            await _service.UpdateProductAsync(request.Id, request.Dto);
            return new UpdateProductCommandResponse
            {
                Message = "Məhsul məlumatları uğurla yeniləndi"
            };
        }
    }
}
