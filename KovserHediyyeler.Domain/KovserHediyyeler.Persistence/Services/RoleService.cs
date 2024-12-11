using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Roles;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
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
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null) throw new NotFoundException("uyğun rol");
                IdentityResult result = await _roleManager.DeleteAsync(role);
                return result.Succeeded;
            }
            catch (Exception)
            {
                throw new FailException("Rol silinərkən xəta baş verdi!");
            }
        }

        public async Task<List<RoleGetDto>> GetAllRolesAsync(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<IdentityRole> rolesQuery = null;

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
            return datas;
        }

        public async Task<RoleGetDto> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            var dto = new RoleGetDto
            {
                Id = id,
                Name = role
            };
            return dto;
        }

        public async Task<bool> UpdateRole(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
