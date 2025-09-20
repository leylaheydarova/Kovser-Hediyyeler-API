using KovserHedieyyeler.Application.DTOs.Brands;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IBrandService
    {
        public Task CreateAsync(BrandCommandDto dto);
        public Task DeleteTemporarilyAsync(Guid id);
        public Task RemovePermanentAsync(Guid id);
        public Task RecoverDataAsync(Guid id);
        public Task UpdateAsync(BrandUpdateDto dto, Guid id);
        public Task UpdateTotalAsync(BrandCommandDto dto, Guid id);
        public Task<List<BrandGetDto>> GetAllAsync(int page, int size);
        public Task<BrandGetDto> GetSingleAsync(Guid id);
    }
}
