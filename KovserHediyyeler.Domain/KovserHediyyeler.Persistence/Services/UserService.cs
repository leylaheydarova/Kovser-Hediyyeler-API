using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Exceptions.FailExceptions;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.WebUsers;
using KovserHediyyeler.Application.Helpers;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
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
            await _addressRepository.AddAsync(address);
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
                District = dto.Address.District,
                Home = dto.Address.Home,
                PostalCode = dto.Address.PostalCode,
                IsCurrentAddress = dto.Address.IsCurrentAddress
            };

            user.Addresses = new List<Address> { address };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new UserResponse
                {
                    Message = "Xəta baş verdi!",
                    isSucceeded = false
                };
            }

            //try
            //{
            //    await _addressRepository.AddAsync(address);
            //    await _addressRepository.SaveAsync();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            await _userManager.AddToRoleAsync(user, "Client");


            return new UserResponse
            {
                isSucceeded = true,
                Message = "Hesab uğurla yaradılmışdır!"
            };
        }

        public async Task<string[]> GetAllUserRolesAsync(string userIdOrEmail)
        {
            WebUser webUser = await FindUserAsync(userIdOrEmail);
            var userRoles = await _userManager.GetRolesAsync(webUser);
            return userRoles.ToArray();
        }

        public async Task RemoveUserAddressAsync(string userIdOrEmail, string addressId)
        {
            var webUser = await _userManager.Users
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            var address = webUser.Addresses.FirstOrDefault(a => a.ID == Guid.Parse(addressId) && !a.isDeleted);
            if (address == null) throw new AddressNotFoundException();
            _addressRepository.RemovePermanently(address);
            await _addressRepository.SaveAsync();
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

        public async Task<WebUserGetSingleDto> GetUserAsync(string userIdOrEmail)
        {
            WebUser webUser = await _userManager.Users.Include(u => u.Addresses).FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            if (webUser == null) throw new UserNotFoundException();
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

        public async Task UpdateUserAsync(string userIdOrEmail, UserDto dto)
        {
            var webUser = await FindUserAsync(userIdOrEmail);
            webUser.FirstName = dto.FirstName != null ? dto.FirstName : webUser.FirstName;
            webUser.MiddleName = dto.MiddleName != null ? dto.MiddleName : webUser.MiddleName;
            webUser.LastName = dto.LastName != null ? dto.LastName : webUser.LastName;
            webUser.PhoneNumber = dto.Phone != null ? dto.Phone : webUser.PhoneNumber;
            await _userManager.UpdateAsync(webUser);
        }

        public async Task UpdateUserAddressAsync(string userIdOrEmail, string addressId, AddressUpdateDto dto)
        {
            var webUser = await _userManager.Users
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            var address = webUser.Addresses.FirstOrDefault(a => a.ID == Guid.Parse(addressId) && !a.isDeleted);
            address.City = dto.City != null ? (City)dto.City : address.City;
            address.Region = dto.Region != null ? dto.Region : address.Region;
            address.District = dto.District != null ? dto.District : address.District != null ? address.District : "";
            address.Street = dto.Street != null ? dto.Street : address.Street;
            address.Home = dto.Home != null ? dto.Home : address.Home;
            address.PostalCode = dto.PostalCode != null ? dto.PostalCode : address.PostalCode;
            address.IsCurrentAddress = dto.IsCurrentAddress != null ? (bool)dto.IsCurrentAddress : address.IsCurrentAddress;
            _addressRepository.Update(address);
            await _addressRepository.SaveAsync();
        }


        public async Task RemoveAccount(string userIdOrEmail)
        {
            var webUser = await _userManager.Users
               .Include(u => u.Addresses)
               .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            if (webUser == null) throw new UserNotFoundException();
            if (webUser.Addresses != null)
            {
                foreach (var address in webUser.Addresses)
                {
                    _addressRepository.RemovePermanently(address);
                }
                await _addressRepository.SaveAsync();
            }
            var currentRoles = await _userManager.GetRolesAsync(webUser);
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(webUser, currentRoles);
            }

            var result = await _userManager.DeleteAsync(webUser);

            if (!result.Succeeded)
            {
                throw new Exception($"Hesab silinərkən xəta baş verdi: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task<List<AddressGetDto>> GetAllUserAddresses(int page, int size, string userIdOrEmail)
        {
            var webUser = await _userManager.Users
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            if (webUser == null) throw new UserNotFoundException();
            var dtos = new List<AddressGetDto>();
            if (webUser.Addresses != null)
            {
                var paginatedAddresses = webUser.Addresses.Skip(page * size).Take(size);
                dtos = paginatedAddresses.Select(address => new AddressGetDto
                {
                    Id = address.ID.ToString(),
                    City = address.City.ToString(),
                    Region = address.Region,
                    District = address.District != null ? address.District : "",
                    Street = address.Street,
                    Home = address.Home,
                    PostalCode = address.PostalCode,
                    IsCurrentAddress = address.IsCurrentAddress
                }).ToList();
            }
            return dtos;
        }

        public async Task AddOrUpdateRoleToUser(string userIdOrEmail, string[] roles)
        {
            // İstifadəçini tapırıq
            var webUser = await FindUserAsync(userIdOrEmail);

            // İstifadəçinin mövcud rollarını alırıq
            var currentRoles = await _userManager.GetRolesAsync(webUser);

            // Mövcud olmayan rolları tapırıq və əlavə edirik
            var rolesToAdd = roles.Except(currentRoles).ToArray();

            if (rolesToAdd.Any())
            {
                var addResult = await _userManager.AddToRolesAsync(webUser, rolesToAdd);
                if (!addResult.Succeeded)
                    throw new Exception($"Rolları əlavə edərkən xəta baş verdi: {string.Join(", ", addResult.Errors.Select(e => e.Description))}");
            }

            // Yalnız əlavə edilməli olan yeni rollar əlavə olunur, amma mövcud rolları dəyişdirməyi unutma.
            // Bütün mövcud rolu silirik və sonra yenidən əlavə edirik, amma yalnız ehtiyac olanları əlavə etmək lazımdır.
            var rolesToRemove = currentRoles.Except(roles).ToArray();
            if (rolesToRemove.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(webUser, rolesToRemove);
                if (!removeResult.Succeeded)
                    throw new Exception($"Rolları silərkən xəta baş verdi: {string.Join(", ", removeResult.Errors.Select(e => e.Description))}");
            }
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
    }
}
