using KovserHedieyyeler.Application.DTOs.Categories;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface ICategoryService
    {
        //Commands
        public Task CreateCategoryAsync(CategoryCommandDto dto);
        public Task DeleteTemporarilyCategoryAsync(Guid id);
        public Task RecoverCategoryDataAsync(Guid id);
        public Task RemovePermanentlyCategoryAsync(Guid id);
        public Task RemovePermanentlyCategoryWithItsChildsAsync(Guid id);
        public Task UpdateTotalCategoryAsync(CategoryCommandDto dto, Guid id);
        public Task UpdateCategoryAsync(CategoryUpdateDto dto, Guid id);

        //Queries
        public Task<CategoryGetDto> GetSingleCategoryAsync(Guid id);
        public Task<List<CategoryGetDto>> GetAllCategoriesAsync();
        public Task<List<CategoryGetDto>> GetAllTopCategoriesAsync(int page, int size);
        public Task<List<CategoryGetDto>> GetAllCategoryChildsAsync(int page, int size, Guid ParentId);
    }
}
