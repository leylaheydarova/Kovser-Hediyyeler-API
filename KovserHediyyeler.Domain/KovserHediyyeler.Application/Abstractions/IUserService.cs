using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Application.DTOs.WebUsers;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IUserService
    {
        int TotalUsersCount { get; }
        //Queries
        Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size);//done
        Task<List<AddressGetDto>> GetAllUserAddresses(int page, int size, string userIdOrEmail);//done
        Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail);//done
        Task<string[]> GetAllUserRolesAsync(string userIdOrEmail);//done

        //Commands
        public Task<UserResponse> CreateUserAsync(RegisterDto dto);//done
        public Task<UserResponse> CreateModeratorAsync(ModeratorDto dto, string role);//done
        Task AddAddressToUserAsync(string userIdOrEmail, AddressCommandDto dto);//done
        Task RemoveUserAddressAsync(string userIdOrEmail, string addressId);//done
        Task UpdateUserAsync(string userIdOrEmail, UserDto dto);//done
        Task UpdateUserAddressAsync(string userIdOrEmail, string addressId, AddressUpdateDto dto);//done
        Task RemoveAccountAsync(string userIdOrEmail);//done
        Task AddRolesToUserAsync(string userIdOrEmail, string[] roles);//done
        Task UpdateUserRoleAsync(string userIdOrEmail, string existingRole, string newRole);//done
        Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task<string> ForgetPasswordAsync(string email, string WebUserUri);//error
        Task ResetPasswordAsync(string email, string newPassword);//error
    }
}
