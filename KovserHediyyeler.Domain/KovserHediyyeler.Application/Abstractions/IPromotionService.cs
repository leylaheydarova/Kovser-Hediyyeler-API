using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHediyyeler.Application.DTOs.Promotion;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IPromotionService
    {
        public Task CreateAsync(PromotionCommandDto dto);
        public Task RemovePermanentAsync(string id);
        public Task UpdateAsync(PromotionPatchDto dto, string id);
        public Task<List<PromotionGetAllDto>> GetAllAsync(int page, int size);
        public Task<PromotionGetSingleDto> GetSingleAsync(string id);
        public Task<DateTime> GetExpireDateAsync(string id);
    }
}
