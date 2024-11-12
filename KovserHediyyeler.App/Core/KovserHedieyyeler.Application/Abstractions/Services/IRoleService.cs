using KovserHedieyyeler.Application.DTOs.Roles;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<(List<RoleGetDto>, int)> GetAllRolesAsync(int page, int size);
        Task<(string id, string name)> GetRoleById(string id);
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string id, string name);
    }
}
