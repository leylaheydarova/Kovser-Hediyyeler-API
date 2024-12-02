using KovserHediyyeler.Application.DTOs.Tokens;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessTokenAsync(int second, WebUser webUser, UserManager<WebUser> userManager);
        string CreateRefreshToken();
    }
}
