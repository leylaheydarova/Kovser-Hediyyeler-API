using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily
{
    public class DeleteTemporarilyShopCommandHandler : IRequestHandler<DeleteTemporarilyShopCommandRequest, DeleteTemporarilyShopCommandResponse>
    {
        readonly IShopService _service;

        public DeleteTemporarilyShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyShopCommandResponse> Handle(DeleteTemporarilyShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyShopAsync(request.Id);

            return new DeleteTemporarilyShopCommandResponse
            {
                Message = "Mağaza müvəqqəti silinmişdir!"
            };
        }
    }
}
