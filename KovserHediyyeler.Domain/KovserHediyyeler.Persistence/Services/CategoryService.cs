using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{

    public class CategoryService : ICategoryService
    {
        readonly ICategoryReadRepository _readRepository;
        readonly ICategoryWriteRepository _writeRepository;

        public CategoryService(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task CreateCategoryAsync(CategoryCommandDto dto)
        {
            if (dto.ParentId != null)
            {
                var parent = await _readRepository.GetWhereAsync(c => c.ID == dto.ParentId && !c.isDeleted, false);
                if (parent == null) throw new NotFoundException("ana kateqoriya");
            }
            Category category = new Category
            {
                Name = dto.Name,
                ParentId = dto.ParentId
            };

            await _writeRepository.AddAsync(category);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyCategoryAsync(Guid id)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");

            _writeRepository.DeleteTemporarily(category);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<CategoryGetDto>> GetAllCategoriesAsync()
        {
            var query = _readRepository.GetAllWhere(x => !x.isDeleted, false, "ParentCategory");
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Select(x => new CategoryGetDto
            {
                Id = x.ID.ToString(),
                Name = x.Name,
                ParentID = x.ParentId.ToString(),
                ParentCategoryName = x.ParentId != null ? x.ParentCategory.Name : "Ana kateqoriya"
            }).ToListAsync();
            return dtos;
        }

        public async Task<List<CategoryGetDto>> GetAllCategoryChildsAsync(int page, int size, Guid ParentId)
        {
            var query = _readRepository.GetAllWhere(c => c.ParentId == ParentId && !c.isDeleted, false, "ParentCategory");
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query
                .Skip(page * size)
                .Take(size)
                .Select(c => new CategoryGetDto
                {
                    Id = c.ID.ToString(),
                    Name = c.Name,
                    ParentID = c.ParentId.ToString(),
                    ParentCategoryName = c.ParentCategory.Name
                }).ToListAsync();
            return dtos;
        }

        public async Task<List<CategoryGetDto>> GetAllTopCategoriesAsync(int page, int size)
        {
            var query = _readRepository.GetAllWhere(x => !x.isDeleted && x.ParentId == null, false);
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(x => new CategoryGetDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    ParentCategoryName = x.ParentId != null ? x.ParentCategory.Name : "Ana kateqoriya"
                }).ToListAsync();
            return dtos;
        }

        public async Task<CategoryGetDto> GetSingleCategoryAsync(Guid id)
        {
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, false, "ParentCategory");
            if (category == null)
            {
                throw new NotFoundException("kateqoriya");
            }
            CategoryGetDto dto = new CategoryGetDto
            {
                Id = category.ID.ToString(),
                Name = category.Name,
                ParentID = category.ParentId.ToString(),
                ParentCategoryName = category.ParentId != null ? category.ParentCategory.Name : "Ana kateqoriya"
            };
            return dto;
        }

        public async Task RecoverCategoryDataAsync(Guid id)
        {
            Category category = await _readRepository.GetWhereAsync(x => x.isDeleted && x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");

            _writeRepository.RecoverData(category);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentlyCategoryAsync(Guid id)
        {
            Category category = await _readRepository.GetWhereAsync(x => x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");
            var query = _readRepository.GetAllWhere(child => !child.isDeleted && child.ParentId == id, true, "ParentCategory");
            List<Category> categoryChilds = new List<Category>();
            categoryChilds = await query.ToListAsync();
            foreach (var categoryChild in categoryChilds)
            {
                if (categoryChild != null)
                {
                    categoryChild.ParentId = null;
                    _writeRepository.Update(categoryChild);
                }
            }
            _writeRepository.RemovePermanently(category);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentlyCategoryWithItsChildsAsync(Guid id)
        {
            Category category = await _readRepository.GetWhereAsync(x => x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");
            var query = _readRepository.GetAllWhere(child => !child.isDeleted && child.ParentId == id, true, "ParentCategory");
            List<Category> categoryChilds = new List<Category>();
            categoryChilds = await query.ToListAsync();
            foreach (var categoryChild in categoryChilds)
            {
                if (categoryChild != null)
                {
                    _writeRepository.RemovePermanently(categoryChild);
                }
            }
            _writeRepository.RemovePermanently(category);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto dto, Guid id)
        {
            if (dto.ParentId != null)
            {
                var parent = await _readRepository.GetWhereAsync(c => c.ID == dto.ParentId && !c.isDeleted, false);
                if (parent == null) throw new NotFoundException("ana kateqoriya");
            }
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");
            category.Name = dto.Name != null ? dto.Name : category.Name;
            category.ParentId = dto.ParentId != null ? dto.ParentId : category.ParentId;
            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateTotalCategoryAsync(CategoryCommandDto dto, Guid id)
        {
            if (dto.ParentId != null)
            {
                var parent = await _readRepository.GetWhereAsync(c => c.ID == dto.ParentId && !c.isDeleted, false);
                if (parent == null) throw new NotFoundException("ana kateqoriya");
            }
            Category category = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == id, true);
            if (category == null) throw new NotFoundException("kateqoriya");
            category.Name = dto.Name;
            category.ParentId = dto.ParentId;

            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();
        }
    }
}
