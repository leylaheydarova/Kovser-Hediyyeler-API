
//using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
//using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
//using KovserHediyyeler.Domain.Models.Identity;

//namespace KovserHedieyyeler.Application.Abstractions.Services
//{
//    public interface IUserService
//    {
//        Task<RegisterUserCommandResponse> CreateAsync(RegisterUserCommandRequest entity);
//        Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
//        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
//        Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size);
//        int TotalUsersCount { get; }
//        Task AssignRoleToUserAsnyc(string userId, string[] roles);
//        Task<string[]> GetRolesToUserAsync(string userIdOrName);
//        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
//    }
//}
