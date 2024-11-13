
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHediyyeler.Domain.Models.Identity;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateAsync(RegisterDto dto);
        Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userIdOrEmail, string resetToken, string newPassword);
        Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size);
        Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail);
        int TotalUsersCount { get; }
        Task AssignRoleToUserAsnyc(string userIdOrEmail, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userIdOrEmail);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
