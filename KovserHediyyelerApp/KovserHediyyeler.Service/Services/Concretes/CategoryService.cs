using AutoMapper;
using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Core.Repositories.Abstractions.Categories;
using KovserHediyyeler.Service.Dtos.Categories;
using KovserHediyyeler.Service.Responses;
using KovserHediyyeler.Service.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReadRepository _readrepository;
        private readonly ICategoryWriteRepository _writerepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryReadRepository readrepository, ICategoryWriteRepository writerepository, IMapper mapper)
        {
            _readrepository = readrepository;
            _writerepository = writerepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateAsync(CategoryPostDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            await _writerepository.AddAsync(category);
            await _writerepository.SaveAsync();
            return new ApiResponse { StatusCode = 201, StatusMessage = "Created Successfully!" };
        }

        public async Task<ApiResponse> DeleteAsync(string id)
        {
            Category category = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            _writerepository.DeleteSoft(category);
            await _writerepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Deleted Temporarily" };
        }

        public async Task<ApiResponseWithData> GetAllAsync()
        {
            var query = _readrepository.GetAllWhere(x => !x.isDeleted, false);
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Select(x => new CategoryGetDto { Id = x.ID.ToString(), Name = x.Name }).ToListAsync();
            return new ApiResponseWithData { StatusCode = 200, Datas = dtos };
        }

        public async Task<ApiResponseWithData> GetAsync(string id)
        {
            Category category = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (category == null)
            {
                return new ApiResponseWithData { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            CategoryGetDto dto = _mapper.Map<CategoryGetDto>(category);
            return new ApiResponseWithData { StatusCode=200, Datas = dto };
        }

        public async Task<ApiResponse> RemoveAsync(string id)
        {
            Category category = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            _writerepository.Delete(category);
            await _writerepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Removed Permanently" };
        }

        public async Task<ApiResponse> UpdateAsync(string id, CategoryPutDto dto)
        {
            Category category = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            category.Name = dto.Name;
            await _writerepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Updated Successfully!"};
        }
    }
}
