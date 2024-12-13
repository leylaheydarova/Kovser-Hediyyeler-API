using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateIsSelected
{
    public class SetIsSelectedTrueCommandHandler : IRequestHandler<SetIsSelectedTrueCommandRequest, SetIsSelectedTrueCommandResponse>
    {
        readonly IBasketService _service;

        public SetIsSelectedTrueCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<SetIsSelectedTrueCommandResponse> Handle(SetIsSelectedTrueCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.SetIsSelectedTrueAsunc(request.ProductIDs, request.CustomerId);
            return new SetIsSelectedTrueCommandResponse
            {
                Message = "Done!"
            };
        }
    }
}
