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
    internal class Temp
    {
    }
}

//using KovserHedieyyeler.Application.Abstractions.Services;
//using KovserHedieyyeler.Application.DTOs.Accounts;
//using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
////using KovserHedieyyeler.Application.Exceptions.FailExceptions;
//using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
////using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
////using KovserHedieyyeler.Application.Helpers;
////using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;
////using KovserHediyyeler.Domain.Models;
//using KovserHediyyeler.Domain.Models.Identity;
//using Microsoft.AspNetCore.Identity;
////using Microsoft.EntityFrameworkCore;

//namespace KovserHediyyeler.Persistence.Services
//{
//    public class UserService : IUserService
//    {
//        readonly UserManager<Domain.Models.Identity.WebUser> _userManager;
//        //readonly IEndpointReadRepository _endpointReadRepository;

//        public UserService(UserManager<WebUser> userManager)//, IEndpointReadRepository endpointReadRepository)
//        {
//            _userManager = userManager;
//            //_endpointReadRepository = endpointReadRepository;
//        }

//        public int TotalUsersCount => _userManager.Users.Count();

//        public async Task AssignRoleToUserAsnyc(string userId, string[] roles)
//        {
//            throw new NotImplementedException();
//            //WebUser user = await _userManager.FindByIdAsync(userId);
//            //if (user != null)
//            //{
//            //    var userRoles = await _userManager.GetRolesAsync(user);
//            //    await _userManager.RemoveFromRolesAsync(user, userRoles);
//            //    await _userManager.AddToRolesAsync(user, roles);
//            //}
//        } //+

//        public async Task<UserResponse> CreateAsync(RegisterDto dto)
//        {
//            IdentityResult result = await _userManager.CreateAsync(new()
//            {
//                Id = Guid.NewGuid().ToString(),
//                FirstName = dto.FirstName,
//                LastName = dto.LastName,
//                MiddleName = dto.MiddleName,
//                PhoneNumber = dto.Phone,
//                Email = dto.Email,
//                UserName = dto.Email
//            }, dto.Password);

//            var response = new UserResponse
//            {
//                isSucceeded = result.Succeeded
//            };
//            if (response.isSucceeded)
//            {
//                response.Message = "İstifadəçi qeydiyyatı uğurla başa çatmışdır!";
//            }
//            else
//            {
//                foreach (var error in result.Errors)
//                {
//                    response.Message += $"{error.Code} - {error.Description}\n";
//                }
//            }

//            return response;
//        } //+

//        public async Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size)
//        {
//            throw new NotImplementedException();
//            //var users = await _userManager.Users
//            //    .Skip(page * size)
//            //    .Take(size)
//            //    .ToListAsync();
//            //return users
//            //    .Select(x => new WebUserGetAllDto
//            //    {
//            //        Id = x.Id.ToString(),
//            //        FirstName = x.FirstName,
//            //        LastName = x.LastName,
//            //        Email = x.Email
//            //    })
//            //    .ToList();
//        } //+

//        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
//        {
//            throw new NotImplementedException();
//            //WebUser user = await _userManager.FindByIdAsync(userIdOrName);
//            //if (user == null)
//            //{
//            //    user = await _userManager.FindByNameAsync(userIdOrName);
//            //}
//            //if (user != null)
//            //{
//            //    var userRoles = await _userManager.GetRolesAsync(user);
//            //    return userRoles.ToArray();
//        }

//        public Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
//        {
//            throw new NotImplementedException();
//        }

//        new string[] { };
//} //+

//public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
//{
//    throw new NotImplementedException();
//    //    var userRoles = await GetRolesToUserAsync(name);
//    //    if (!userRoles.Any())
//    //        return false;
//    //    Endpoint? endpoint = await _endpointReadRepository.Table
//    //             .Include(e => e.Roles)
//    //             .FirstOrDefaultAsync(e => e.Code == code);
//    //    if (endpoint == null)
//    //        return false;
//    //    var hasRole = false;
//    //    var endpointRoles = endpoint.Roles.Select(r => r.Name);
//    //    foreach (var userRole in userRoles)
//    //    {
//    //        foreach (var endpointRole in endpointRoles)
//    //            if (userRole == endpointRole)
//    //                return true;
//    //    }

//    //    return false;
//}

//public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
//{
//    throw new NotImplementedException();
//    //WebUser user = await _userManager.FindByIdAsync(userId);
//    //if (user != null)
//    //{
//    //    resetToken = resetToken.UrlDecode();
//    //    IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
//    //    if (result.Succeeded)
//    //        await _userManager.UpdateSecurityStampAsync(user);
//    //    else
//    //        throw new PasswordChangeFailedException();
//    //}
//}

//public async Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
//{
//    if (user != null)
//    {
//        user.RefreshToken = refreshToken;
//        user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
//        await _userManager.UpdateAsync(user);
//    }
//    else throw new UserNotFoundException();
//}
//    }
//}
