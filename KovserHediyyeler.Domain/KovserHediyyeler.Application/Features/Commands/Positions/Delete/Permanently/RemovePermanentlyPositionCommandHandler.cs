using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Permanently
{
    public class RemovePermanentlyPositionCommandHandler : IRequestHandler<RemovePermanentlyPositionCommandRequest, RemovePermanentlyPositionCommandResponse>
    {
        readonly IPositionService _service;

        public RemovePermanentlyPositionCommandHandler(IPositionService service)
        {
            _service = service;
        }

        public async Task<RemovePermanentlyPositionCommandResponse> Handle(RemovePermanentlyPositionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.RemovePermanentlyPositionAsync(request.Id);

            return new RemovePermanentlyPositionCommandResponse
            {
                Message = "Vəzifə uğurla silinmişdir!"
            };
        }
    }
}
