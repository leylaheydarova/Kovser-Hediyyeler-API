using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Roles;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(), Name = name });

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            try
            {
                Role? role = await _roleManager.FindByIdAsync(id);
                if (role == null) throw new RoleNotFoundException();
                IdentityResult result = await _roleManager.DeleteAsync(role);
                return result.Succeeded;
            }
            catch (Exception)
            {
                throw new Exception("Rol silinərkən xəta baş verdi!");
            }
        }



        public async Task<(List<RoleGetDto>, int)> GetAllRolesAsync(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<Role> rolesQuery = null;

            if (page != -1 && size != -1)
                rolesQuery = query.Skip(page * size).Take(size);
            else
                rolesQuery = query;

            var datas = new List<RoleGetDto>();
            datas = await rolesQuery.Select(r => new RoleGetDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToListAsync();
            var count = query.Count();
            return (datas, count);
        }

        public async Task<(string id, string name)> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id, role);
        }

        public async Task<bool> UpdateRole(string id, string name)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
