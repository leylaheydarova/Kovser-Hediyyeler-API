using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Temporarily
{
    public class DeleteTemporarilyPositionCommandHandler : IRequestHandler<DeleteTemporarilyPositionCommandRequest, DeleteTemporarilyPositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public DeleteTemporarilyPositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<DeleteTemporarilyPositionCommandResponse> Handle(DeleteTemporarilyPositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (position == null) throw new PositionNotFoundException();
            _writeRepository.DeleteTemporarily(position);
            await _writeRepository.SaveAsync();
            return new DeleteTemporarilyPositionCommandResponse
            {
                Message = "Vəzifə müvəqqəti silindi"
            };
        }
    }
}
