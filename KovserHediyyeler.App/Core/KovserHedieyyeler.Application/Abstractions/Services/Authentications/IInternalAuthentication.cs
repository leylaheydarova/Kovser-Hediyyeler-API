using KovserHedieyyeler.Application.DTOs.Tokens;

namespace KovserHedieyyeler.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}

