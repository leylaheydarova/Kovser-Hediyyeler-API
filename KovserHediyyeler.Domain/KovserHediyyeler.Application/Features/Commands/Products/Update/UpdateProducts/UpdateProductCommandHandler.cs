using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProducts
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductPatchService _service;

        public UpdateProductCommandHandler(IProductPatchService service)
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
