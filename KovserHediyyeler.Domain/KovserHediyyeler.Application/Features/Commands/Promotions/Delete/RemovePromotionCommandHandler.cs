using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Delete
{
    public class RemovePromotionCommandHandler : IRequestHandler<RemovePromotionCommandRequest, RemovePromotionCommandResponse>
    {
        readonly IPromotionService _service;

        public RemovePromotionCommandHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<RemovePromotionCommandResponse> Handle(RemovePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentAsync(request.Id);

            return new RemovePromotionCommandResponse
            {
                Message = "Kampaniya uğurla silindi"
            };
        }
    }
}
