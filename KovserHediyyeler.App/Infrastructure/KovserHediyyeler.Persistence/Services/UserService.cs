using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.DTOs.Accounts;
using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.WebUsers.Users;
using KovserHedieyyeler.Application.Exceptions.FailExceptions;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Helpers;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public int TotalUsersCount => _userManager.Users.Count();

        async Task<WebUser> FindUserAsync(string userIdOrEmail)
        {
            WebUser webUser = await _userManager.FindByIdAsync(userIdOrEmail);
            if (webUser == null)
            {
                webUser = await _userManager.FindByEmailAsync(userIdOrEmail);
            }

            if (webUser == null) throw new UserNotFoundException();
            return webUser;
        }

        public async Task AssignRoleToUserAsnyc(string userIdOrEmail, string[] roles)
        {
            WebUser webUser = await FindUserAsync(userIdOrEmail);
            if (webUser == null) throw new UserNotFoundException();

            var userRoles = await _userManager.GetRolesAsync(webUser);
            await _userManager.RemoveFromRolesAsync(webUser, userRoles);
            await _userManager.AddToRolesAsync(webUser, roles);
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

            await AssignRoleToUserAsnyc(user.Id, new[] { "Client" });

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

        public async Task<List<WebUserGetAllDto>> GetAllUsersAsync(int page, int size)
        {
            var webUsers = await _userManager.Users
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
            List<WebUserGetAllDto> dtos = new List<WebUserGetAllDto>();
            dtos = webUsers.Select(w => new WebUserGetAllDto
            {
                Id = w.Id,
                FirstName = w.FirstName,
                LastName = w.LastName,
                Email = w.Email
            }).ToList();
            return dtos;
        }

        public async Task<string[]> GetRolesToUserAsync(string userIdOrEmail)
        {
            WebUser webUser = await FindUserAsync(userIdOrEmail);
            var userRoles = await _userManager.GetRolesAsync(webUser);
            return userRoles.ToArray();
        }

        public async Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail)
        {
            WebUser webUser = await _userManager.Users.Include(u => u.Addresses).FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            var currentAddress = webUser.Addresses.FirstOrDefault(a => a.IsCurrentAddress == true && !a.isDeleted);
            var dto = new WebUserGetSingleDto
            {
                Id = webUser.Id,
                FirstName = webUser.Email,
                MiddleName = webUser.MiddleName,
                LastName = webUser.LastName,
                Phone = webUser.PhoneNumber,
                Email = webUser.Email,
                Address = new AddressGetDto
                {
                    Id = currentAddress.ID.ToString(),
                    City = currentAddress.City.ToString(),
                    Region = currentAddress.Region,
                    Street = currentAddress.Street,
                    Home = currentAddress.Home,
                    PostalCode = currentAddress.PostalCode,
                    IsCurrentAddress = currentAddress.IsCurrentAddress
                }
            };
            return dto;
        }

        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePasswordAsync(string userIdOrEmail, string resetToken, string newPassword)
        {
            WebUser webUser = await FindUserAsync(userIdOrEmail);
            resetToken = resetToken.UrlDecode();
            IdentityResult result = await _userManager.ResetPasswordAsync(webUser, resetToken, newPassword);
            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(webUser);
            }
            else throw new PasswordChangeFailedException();
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
