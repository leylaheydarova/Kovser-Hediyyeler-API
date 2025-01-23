using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Shops.Update.Recover
{
    public class RecoverShopCommandHandler : IRequestHandler<RecoverShopCommandRequest, RecoverShopCommandResponse>
    {
        readonly IShopService _service;

        public RecoverShopCommandHandler(IShopService service)
        {
            _service = service;
        }

        public async Task<RecoverShopCommandResponse> Handle(RecoverShopCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverShopDataAsync(request.Id);

            return new RecoverShopCommandResponse()
            {
                Message = "Mağaza məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
