using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.UpdateTotalPosition
{
    public class UpdateTotalPositionCommandHandler : IRequestHandler<UpdateTotalPositionCommandRequest, UpdateTotalPositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public UpdateTotalPositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalPositionCommandResponse> Handle(UpdateTotalPositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            position.Status = request.Dto.Status;
            _writeRepository.Update(position);
            await _writeRepository.SaveAsync();
            return new UpdateTotalPositionCommandResponse
            {
                Message = "Vəzifə məlumatlarl uğurla yeniləndi!"
            };
        }
    }
}
