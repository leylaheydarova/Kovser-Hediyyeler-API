using KovserHediyyeler.Application.DTOs.Roles;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IRoleService
    {
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string id, string name);
        Task<List<RoleGetDto>> GetAllRolesAsync(int page, int size);
        Task<RoleGetDto> GetRoleById(string id);
    }
}
