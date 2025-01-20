using KovserHedieyyeler.Application.DTOs.Positions;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IPositionService
    {
        //Commands
        Task CreatePositionAsync(PositionCommandDto dto);
        Task DeleteTemporarilyPositionAsync(Guid id);
        Task RecoverPositionDataAsync(Guid id);
        Task RemovePermanentlyPositionAsync(Guid id);
        Task UpdatePositionAsync(Guid id, PositionCommandDto dto);
    }
}
