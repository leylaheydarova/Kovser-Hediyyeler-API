using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Promotions.Create
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommandRequest, CreatePromotionCommandResponse>
    {
        readonly IPromotionService _service;

        public CreatePromotionCommandHandler(IPromotionService service)
        {
            _service = service;
        }

        public async Task<CreatePromotionCommandResponse> Handle(CreatePromotionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateAsync(request.Dto);

            return new CreatePromotionCommandResponse
            {
                StatusCode = 201,
                Message = "Kampaniya uğurla yaradıldı"
            };
        }
    }
}
