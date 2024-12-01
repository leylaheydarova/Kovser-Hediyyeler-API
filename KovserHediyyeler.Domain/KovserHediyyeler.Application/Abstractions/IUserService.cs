using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Application.DTOs.WebUsers;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IUserService
    {
        public Task<UserResponse> CreateUserAsync(RegisterDto dto);
        public Task<UserResponse> CreateModeratorAsync(ModeratorDto dto, string role);
        int TotalUsersCount { get; }
        Task<string[]> GetRolesToUserAsync(string userIdOrEmail);
        Task AddAddressToUserAsync(string userIdOrEmail, AddressCommandDto dto);
        Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size);
        Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail);
    }
}
