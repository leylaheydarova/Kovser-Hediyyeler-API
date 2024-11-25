using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandService _service;

        public UpdateBrandCommandHandler(IBrandService service)
        {
            _service = service;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Dto, request.Id);

            return new UpdateBrandCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
