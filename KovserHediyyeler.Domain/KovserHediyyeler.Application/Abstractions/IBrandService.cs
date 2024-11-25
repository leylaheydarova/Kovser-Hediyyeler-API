using KovserHedieyyeler.Application.DTOs.Brands;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IBrandService
    {
        public Task CreateAsync(BrandCommandDto dto);
        public Task DeleteTemporarilyAsync(string id);
        public Task RemovePermanentAsync(string id);
        public Task RecoverDataAsync(string id);
        public Task UpdateAsync(BrandUpdateDto dto, string id);
        public Task UpdateTotalAsync(BrandCommandDto dto, string id);
        public Task<List<BrandGetDto>> GetAllAsync(int page, int size);
        public Task<BrandGetDto> GetSingleAsync(string id);
    }
}
