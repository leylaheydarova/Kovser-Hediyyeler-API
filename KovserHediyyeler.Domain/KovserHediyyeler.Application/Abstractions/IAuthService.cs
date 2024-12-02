using KovserHediyyeler.Application.Abstractions.Authentication;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IAuthService : IInternalAuthentication
    {
        Task PasswordResetAsnyc(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userIdOrEmail);
    }
}
