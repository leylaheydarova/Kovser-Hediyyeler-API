using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHediyyeler.Application.DTOs.Promotion;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IPromotionService
    {
        public Task CreateAsync(PromotionCommandDto dto);
        public Task RemovePermanentAsync(Guid id);
        public Task UpdateAsync(PromotionPatchDto dto, Guid id);
        public Task<List<PromotionGetAllDto>> GetAllAsync(int page, int size);
        public Task<PromotionGetSingleDto> GetSingleAsync(Guid id);
        public Task<DateTime> GetExpireDateAsync(Guid id);
    }
}
