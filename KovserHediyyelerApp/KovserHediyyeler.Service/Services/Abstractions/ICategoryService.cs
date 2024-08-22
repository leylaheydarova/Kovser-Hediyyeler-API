using KovserHediyyeler.Service.Dtos.Categories;
using KovserHediyyeler.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ApiResponseWithData> GetAllAsync();
        Task<ApiResponse> CreateAsync(CategoryPostDto dto);
        Task<ApiResponse> DeleteAsync(string id);
        Task<ApiResponse> RemoveAsync(string id);
        Task<ApiResponseWithData> GetAsync(string id);
        Task<ApiResponse> UpdateAsync(string id, CategoryPutDto dto);
    }
}
