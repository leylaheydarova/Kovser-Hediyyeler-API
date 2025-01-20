using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Positions.Update.Recover
{
    public class RecoverPositionCommandHandler : IRequestHandler<RecoverPositionCommandRequest, RecoverPositionCommandResponse>
    {
        readonly IPositionService _service;

        public RecoverPositionCommandHandler(IPositionService service)
        {
            _service = service;
        }

        public async Task<RecoverPositionCommandResponse> Handle(RecoverPositionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RecoverPositionDataAsync(request.Id);

            return new RecoverPositionCommandResponse
            {
                Message = "Vəzifə məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
