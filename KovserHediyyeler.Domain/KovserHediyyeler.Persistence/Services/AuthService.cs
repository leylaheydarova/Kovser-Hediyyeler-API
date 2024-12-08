using KovserHedieyyeler.Application.Exceptions.FailExceptions;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.DTOs.Tokens;
using KovserHediyyeler.Application.Helpers;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace KovserHediyyeler.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<WebUser> _userManager;
        readonly SignInManager<WebUser> _signInManager;
        readonly HttpClient _httpClient;
        readonly IConfiguration _configuration;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<WebUser> userManager, SignInManager<WebUser> signInManager, HttpClient httpClient, IConfiguration configuration, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpClient = httpClient;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        async Task<Token> CreateUserExternalAsync(WebUser user, string email, string firtsName, string lastName, UserLoginInfo info, int accessTokenLifeTime)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {

                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        FirstName = firtsName,
                        LastName = lastName,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins
                Token token = await _tokenHandler.CreateAccessTokenAsync(accessTokenLifeTime, user, _userManager);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }


        public async Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
                user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new UserNotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = await _tokenHandler.CreateAccessTokenAsync(accessTokenLifeTime, user, _userManager);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async Task PasswordResetAsnyc(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
                resetToken = resetToken.UrlEncode();

                //await _mailService.SendPasswordResetMailAsync(email, user.Id.ToString(), resetToken);
            }//in progress
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            WebUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = await _tokenHandler.CreateAccessTokenAsync(15, user, _userManager);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new UserNotFoundException();
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userIdOrEmail)
        {
            WebUser user = await _userManager.FindByIdAsync(userIdOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userIdOrEmail);
            }
            if (user != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);
                resetToken = resetToken.UrlDecode();

                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }
    }
}
