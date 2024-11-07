using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<WebUser> _userManager;
        readonly IAddressWriteRepository _addressRepository;

        public UserService(UserManager<WebUser> userManager, IAddressWriteRepository addressRepository)
        {
            _userManager = userManager;
            _addressRepository = addressRepository;
        }

        public int TotalUsersCount => throw new NotImplementedException();

        public Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> CreateAsync(RegisterDto dto)
        {
            var user = new WebUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.Phone,
                Email = dto.Email,
                UserName = dto.Email,
                Basket = new(),
                WishList = new()
            };
            Address address = new Address
            {
                ID = Guid.NewGuid(),
                City = dto.Address.City,
                Region = dto.Address.Region,
                Street = dto.Address.Street,
                Home = dto.Address.Home,
                PostalCode = dto.Address.PostalCode,
                IsCurrentAddress = dto.Address.IsCurrentAddress
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            try
            {
                await _addressRepository.AddAsync(address);
                await _addressRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            if (!result.Succeeded)
            {
                return new UserResponse
                {
                    Message = "Xəta baş verdi!",
                    isSucceeded = false
                };
            }
            return new UserResponse
            {
                isSucceeded = true,
                Message = "Hesab uğurla yaradılmışdır!"
            };
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
