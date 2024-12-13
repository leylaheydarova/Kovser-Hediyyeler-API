using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Baskets.Update.UpdateItemCount
{
    public class UpdateItemCountCommandHandler : IRequestHandler<UpdateItemCountCommandRequest, UpdateItemCountCommandResponse>
    {
        readonly IBasketService _service;

        public UpdateItemCountCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<UpdateItemCountCommandResponse> Handle(UpdateItemCountCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateItemCountAsync(request.Dto.ProductId, request.Dto.Count, request.Dto.UserId);
            return new UpdateItemCountCommandResponse()
            {
                Message = "Məhsul sayı uğurla yeniləndi!"
            };
        }
    }
}
