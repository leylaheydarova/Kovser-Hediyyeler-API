using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.WebUsers;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
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

        public int TotalUsersCount => _userManager.Users.Count();

        public async Task AddAddressToUserAsync(string userIdOrEmail, AddressCommandDto dto)
        {
            var webUser = await FindUserAsync(userIdOrEmail);
            var address = new Address
            {
                ID = Guid.NewGuid(),
                City = dto.City,
                Region = dto.Region,
                Street = dto.Street,
                Home = dto.Home,
                PostalCode = dto.PostalCode,
                IsCurrentAddress = dto.IsCurrentAddress
            };
            webUser.Addresses.Add(address);
            await _addressRepository.SaveAsync();
        }

        public async Task<UserResponse> CreateModeratorAsync(ModeratorDto dto, string role)
        {
            var user = new WebUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName,
                PhoneNumber = dto.Phone,
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                return new UserResponse
                {
                    isSucceeded = false
                };
            }
            return new UserResponse
            {
                isSucceeded = true,
                Message = "Hesab uğurla yaradılmışdır!"
            };
        }

        public async Task<UserResponse> CreateUserAsync(RegisterDto dto)
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
                //Basket = new(),
                //WishList = new()
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

            await _userManager.AddToRoleAsync(user, "Client");

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

        public Task<string[]> GetRolesToUserAsync(string userIdOrEmail)
        {
            throw new NotImplementedException();
        }

        public Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail)
        {
            throw new NotImplementedException();
        }
    }
}
