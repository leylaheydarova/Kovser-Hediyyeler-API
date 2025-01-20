using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Temporarily
{
    public class DeleteTemporarilyPositionCommandHandler : IRequestHandler<DeleteTemporarilyPositionCommandRequest, DeleteTemporarilyPositionCommandResponse>
    {
        readonly IPositionService _service;

        public DeleteTemporarilyPositionCommandHandler(IPositionService service)
        {
            _service = service;
        }

        public async Task<DeleteTemporarilyPositionCommandResponse> Handle(DeleteTemporarilyPositionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.DeleteTemporarilyPositionAsync(request.Id);

            return new DeleteTemporarilyPositionCommandResponse
            {
                Message = "Vəzifə müvəqqəti silindi"
            };
        }
    }
}
