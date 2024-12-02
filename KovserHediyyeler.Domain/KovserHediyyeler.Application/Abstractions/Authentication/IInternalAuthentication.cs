using KovserHediyyeler.Application.DTOs.Tokens;

namespace KovserHediyyeler.Application.Abstractions.Authentication
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
