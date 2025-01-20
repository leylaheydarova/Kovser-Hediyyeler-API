using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Repositories.Positions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.Update
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommandRequest, UpdatePositionCommandResponse>
    {
        readonly IPositionService _service;

        public UpdatePositionCommandHandler(IPositionService service)
        {
            _service = service;
        }

        public async Task<UpdatePositionCommandResponse> Handle(UpdatePositionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdatePositionAsync(request.Id, request.Dto);

            return new UpdatePositionCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
