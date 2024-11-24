using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IDepartmentService
    {
        public Task CreateDepartmentAsync(DepartmentCommandDto dto);
        public Task CreateDepartmentSocialMediaAsync(SocialMediaCommandDto dto, string DepartmentId);
        public Task DeleteTemporarilyDepartment(string id);
        public Task RemovePermanentlyDepartmentAsync(string id);
        public Task RemovePermanentlyDepartmentSocialMediaAsync(string id);
        public Task RecoverDepartmentAsync(string id);
        public Task UpdateTotalDepartmentAsync(DepartmentCommandDto dto, string id);
        public Task UpdateDepartmentAsync(DepartmentUpdateDto dto, string id);
        public Task UpdateDepartmentSocialMediaAsync(SocialMediaUpdateDto dto, string id);

        public Task<List<DepartmentGetAllDto>> GetAllDepartments(int page, int size);
        public Task<List<SocialMediaGetDto>> GetAllDepartmentSocialMedias(string DepartmentId);
        public Task<DepartmentGetSingleDto> GetSingleDepartment(string id);
    }
}
