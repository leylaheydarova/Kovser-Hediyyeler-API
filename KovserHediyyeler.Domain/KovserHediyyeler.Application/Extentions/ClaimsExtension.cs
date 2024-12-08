using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using System.Security.Claims;

namespace KovserHediyyeler.Application.Extentions
{
    public static class ClaimsExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (user.Claims == null)
                throw new ArgumentNullException(nameof(user.Claims));

            var claim = user.Identities.First().Claims.FirstOrDefault(c => c.Type == "Id");

            if (claim == null)
                throw new InvalidTokenException();

            return claim.Value;
        }

        public static string? TryGetUserId(this ClaimsPrincipal? user)
        {
            if (user?.Claims == null)
                return null;

            var claim = user.Identities.First().Claims.FirstOrDefault(c => c.Type == "Id");

            return claim?.Value;
        }
    }
}
