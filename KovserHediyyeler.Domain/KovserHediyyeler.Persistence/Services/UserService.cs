using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.WebUsers;
using KovserHediyyeler.Application.Exceptions.FailExceptions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KovserHediyyeler.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<WebUser> _userManager;
        readonly IAddressWriteRepository _addressRepository;
        readonly IEmailService _emailService;
        readonly ITokenHandler _tokenHandler;
        readonly IBasketWriteRepository _basketRepository;
        readonly IWishListWriteRepository _wishListRepository;

        public UserService(UserManager<WebUser> userManager, IAddressWriteRepository addressRepository, IEmailService emailService, ITokenHandler tokenHandler, IBasketWriteRepository basketRepository, IWishListWriteRepository wishListRepository)
        {
            _userManager = userManager;
            _addressRepository = addressRepository;
            _emailService = emailService;
            _tokenHandler = tokenHandler;
            _basketRepository = basketRepository;
            _wishListRepository = wishListRepository;
        }

        async Task<WebUser> FindUserAsync(string userIdOrEmail)
        {
            WebUser webUser = await _userManager.FindByIdAsync(userIdOrEmail);
            if (webUser == null)
            {
                webUser = await _userManager.FindByEmailAsync(userIdOrEmail);
            }

            if (webUser == null) throw new NotFoundException("istifadəçi");
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
                District = dto.District,
                Street = dto.Street,
                Home = dto.Home,
                PostalCode = dto.PostalCode,
                IsCurrentAddress = dto.IsCurrentAddress,
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
                Basket = new(),
                WishList = new()
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
            if (address == null) throw new NotFoundException("ünvan");
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
            if (webUser == null) throw new NotFoundException("istifadəçi");
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


        public async Task RemoveAccountAsync(string userIdOrEmail)
        {
            using var transaction = await _wishListRepository.BeginTransactionAsync();
            try
            {
                var webUser = await _userManager.Users
               .Include(u => u.Addresses)
               .Include(u => u.Basket)
               .Include(u => u.WishList)
               .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
                if (webUser == null) throw new NotFoundException("istifadəçi");
                if (webUser.Addresses != null)
                {
                    foreach (var address in webUser.Addresses)
                    {
                        _addressRepository.RemovePermanently(address);
                    }
                    await _addressRepository.SaveAsync();
                }

                _basketRepository.RemovePermanently(webUser.Basket);

                _wishListRepository.RemovePermanently(webUser.WishList);

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
                await _basketRepository.SaveAsync();
                await _wishListRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<AddressGetDto>> GetAllUserAddresses(int page, int size, string userIdOrEmail)
        {
            var webUser = await _userManager.Users
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == userIdOrEmail || u.Email == userIdOrEmail);
            if (webUser == null) throw new NotFoundException("istifadəçi");
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

        public async Task UpdateRefreshTokenAsync(string refreshToken, WebUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else throw new NotFoundException("istifadəçi");
        }

        public async Task<string> ForgetPasswordAsync(string email, string WebUserUri)
        {
            var webUser = await FindUserAsync(email!);
            var token = await _userManager.GeneratePasswordResetTokenAsync(webUser);
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", email!}
            };
            var callback = QueryHelpers.AddQueryString(WebUserUri!, param);
            Console.WriteLine("Generated Callback URL: " + callback);
            var subject = $"{webUser.Email}, Şifrə sıfırlama tokeni";
            var body = $"<p>Zəhmət olmasa, şifrəni yeniləmək üçün aşağıdakı linkə daxil olun:</p><a href='#'>{callback}</a>";
            await _emailService.SendEmailAsync(webUser.Email!, subject, body);
            return token;
        }

        public async Task ResetPasswordAsync(string resetToken, string email, string newPassword, string confirmPassword)
        {
            //var isValidToken = _tokenHandler.ValidateToken(resetToken);
            //if (!isValidToken)
            //{
            //    throw new InvalidTokenException();
            //}
            var webUser = await FindUserAsync(email);
            if (newPassword != confirmPassword) throw new PasswordChangeFailedException("Şifrələr eyniləşmədi! Zəhmət olmasa, hər iki xanaya eyni şifrəni daxil edin");
            try
            {
                var result = await _userManager.ResetPasswordAsync(webUser, resetToken, newPassword);
                if (!result.Succeeded)
                {
                    throw new PasswordChangeFailedException();
                }
            }
            catch (Exception ex)
            {
                // Xətanı burada istədiyin şəkildə idarə edə bilərsən
                throw new PasswordChangeFailedException("Şifrəni sıfırlayarkən xəta baş verdi.", ex);
            }

        }

        public async Task AddRolesToUserAsync(string userIdOrEmail, string[] roles)
        {
            var webUser = await FindUserAsync(userIdOrEmail);
            var result = await _userManager.AddToRolesAsync(webUser, roles);
            if (!result.Succeeded) throw new AddRoleFailException();
        }

        public async Task UpdateUserRoleAsync(string userIdOrEmail, string existingRole, string newRole)
        {
            var webUser = await FindUserAsync(userIdOrEmail);
            var userRoles = await GetAllUserRolesAsync(userIdOrEmail);
            foreach (var userRole in userRoles)
            {
                if (userRole == existingRole)
                {
                    if (userRole == newRole) throw new FailException("İstifadəçi bu rola öncədən sahibdir!");
                    var removeResult = await _userManager.RemoveFromRoleAsync(webUser, userRole);
                    if (!removeResult.Succeeded) throw new RemoveRoleFailException();
                    var addResult = await _userManager.AddToRoleAsync(webUser, newRole);
                    if (!addResult.Succeeded) throw new AddRoleFailException();
                }
            }
        }
    }
}


//todo: need to develop UpdatePassword