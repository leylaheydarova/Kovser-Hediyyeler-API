
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHediyyeler.Domain.Models.Identity;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateAsync(RegisterDto dto); //integrated
        Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userIdOrEmail, string resetToken, string newPassword);
        Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size);
        Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail);
        int TotalUsersCount { get; } //integrated
        Task AssignRoleToUserAsnyc(string userIdOrEmail, string[] roles); //should not be integrated
        Task<string[]> GetRolesToUserAsync(string userIdOrEmail); //integrated
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
        Task AddAddressToUserAsync(string userIdOrEmail, AddressCommandDto dto);//integrated
    }
}
