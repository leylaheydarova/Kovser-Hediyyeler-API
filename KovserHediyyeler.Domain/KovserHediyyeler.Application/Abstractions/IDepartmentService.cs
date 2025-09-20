using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IDepartmentService
    {
        public Task CreateDepartmentAsync(DepartmentCommandDto dto);
        public Task CreateDepartmentSocialMediaAsync(SocialMediaCommandDto dto, Guid DepartmentId);
        public Task DeleteTemporarilyDepartment(Guid id);
        public Task RemovePermanentlyDepartmentAsync(Guid id);
        public Task RemovePermanentlyDepartmentSocialMediaAsync(Guid id);
        public Task RecoverDepartmentAsync(Guid id);
        public Task UpdateTotalDepartmentAsync(DepartmentCommandDto dto, Guid id);
        public Task UpdateDepartmentAsync(DepartmentUpdateDto dto, Guid id);
        public Task UpdateDepartmentSocialMediaAsync(SocialMediaUpdateDto dto, Guid id);

        public Task<List<DepartmentGetAllDto>> GetAllDepartments(int page, int size);
        public Task<List<SocialMediaGetDto>> GetAllDepartmentSocialMedias(Guid DepartmentId);
        public Task<DepartmentGetSingleDto> GetSingleDepartment(Guid id);
    }
}
