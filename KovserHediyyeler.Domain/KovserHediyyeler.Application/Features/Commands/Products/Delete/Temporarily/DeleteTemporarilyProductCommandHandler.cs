using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Temporarily
{
    public class DeleteTemporarilyProductCommandHandler : IRequestHandler<DeleteTemporarilyProductCommandRequest, DeleteTemporarilyProductCommandResponse>
    {
        readonly IProductDeleteService _service;

        public DeleteTemporarilyProductCommandHandler(IProductDeleteService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyProductCommandResponse> Handle(DeleteTemporarilyProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyProductAsync(request.Id);
            return new DeleteTemporarilyProductCommandResponse
            {
                Message = "Məhsul müvəqqəti silinmişdir!"
            };
        }
    }
}
