using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Recover
{
    public class RecoverPositionCommandHandler : IRequestHandler<RecoverPositionCommandRequest, RecoverPositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public RecoverPositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RecoverPositionCommandResponse> Handle(RecoverPositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(p => p.isDeleted && p.ID.ToString() == request.Id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            _writeRepository.RecoverData(position);
            await _writeRepository.SaveAsync();
            return new RecoverPositionCommandResponse
            {
                Message = "Vəzifə məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
