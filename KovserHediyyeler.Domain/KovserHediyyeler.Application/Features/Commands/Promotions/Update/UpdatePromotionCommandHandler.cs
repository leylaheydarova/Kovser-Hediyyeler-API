using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Update
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommandRequest, UpdatePromotionCommandResponse>
    {
        readonly IPromotionService _service;

        public UpdatePromotionCommandHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<UpdatePromotionCommandResponse> Handle(UpdatePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Dto, request.Id);

            return new UpdatePromotionCommandResponse
            {
                Message = "Kampaniya uğurla yeniləndi"
            };
        }
    }
}
