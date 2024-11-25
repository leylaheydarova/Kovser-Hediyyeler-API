using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Temporarily
{
    public class DeleteTemporarilyBrandCommandHandler : IRequestHandler<DeleteTemporarilyBrandCommandRequest, DeleteTemporarilyBrandCommandResponse>
    {
        readonly IBrandService _service;

        public DeleteTemporarilyBrandCommandHandler(IBrandService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyBrandCommandResponse> Handle(DeleteTemporarilyBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyAsync(request.Id);

            return new DeleteTemporarilyBrandCommandResponse
            {
                Message = "Brend müvəqqəti silindi!"
            };
        }
    }
}
