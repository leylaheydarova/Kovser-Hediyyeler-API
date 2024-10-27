using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<WebUser> _userManager;

        public UserService(UserManager<WebUser> userManager)
        {
            _userManager = userManager;
        }

        public int TotalUsersCount => throw new NotImplementedException();

        public Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> CreateAsync(RegisterDto dto)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.Phone,
                Email = dto.Email,
                UserName = dto.Email
            }, dto.Password);

            var response = new UserResponse
            {
                isSucceeded = result.Succeeded
            };
            if (response.isSucceeded)
            {
                response.Message = "İstifadəçi qeydiyyatı uğurla başa çatmışdır!";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }

        public Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else throw new UserNotFoundException();
        }
    }
}
