using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services
{
    public class PositionService : IPositionService
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public PositionService(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task CreatePositionAsync(PositionCommandDto dto)
        {
            Position position = new Position
            {
                ID = Guid.NewGuid(),
                Status = dto.Status
            };
            await _writeRepository.AddAsync(position);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyPositionAsync(Guid id)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            _writeRepository.DeleteTemporarily(position);
            await _writeRepository.SaveAsync();
        }

        public async Task RecoverPositionDataAsync(Guid id)
        {
            Position position = await _readRepository.GetWhereAsync(x => x.isDeleted && x.ID == id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            _writeRepository.RecoverData(position);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentlyPositionAsync(Guid id)
        {
            Position position = await _readRepository.GetByIdAsync(id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            _writeRepository.RemovePermanently(position);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdatePositionAsync(Guid id, PositionCommandDto dto)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, true);
            if (position == null) throw new NotFoundException("vəzifə");
            position.Status = dto.Status;
            _writeRepository.Update(position);
            await _writeRepository.SaveAsync();
        }
    }
}
