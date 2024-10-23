using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHedieyyeler.Application.Features.Commands.WebUsers.Register;
using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<WebUser> _userManager;
        readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<WebUser> userManager, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
        }

        public int TotalUsersCount => throw new NotImplementedException();

        public Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterUserCommandResponse> CreateAsync(RegisterUserCommandRequest model)
        {
            throw new NotImplementedException();
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

        public Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            throw new NotImplementedException();
        }
    }
}
