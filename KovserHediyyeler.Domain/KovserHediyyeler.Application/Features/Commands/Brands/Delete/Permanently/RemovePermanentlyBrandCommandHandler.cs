using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently
{
    public class RemovePermanentlyBrandCommandHandler : IRequestHandler<RemovePermanentlyBrandCommandRequest, RemovePermanentlyBrandCommandResponse>
    {
        readonly IBrandService _service;

        public RemovePermanentlyBrandCommandHandler(IBrandService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyBrandCommandResponse> Handle(RemovePermanentlyBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentAsync(request.Id);

            return new RemovePermanentlyBrandCommandResponse
            {
                Message = "Brend uğurla silindi!"
            };
        }
    }
}
