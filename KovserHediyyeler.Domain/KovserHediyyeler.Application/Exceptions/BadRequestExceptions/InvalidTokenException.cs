using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.BadRequestExceptions
{
    public class InvalidTokenException : BaseException
    {
        public InvalidTokenException() : base("Token ya etibarsızdır, ya da zamanı bitmişdir")
        {
        }

        public InvalidTokenException(string message) : base(message)
        {
        }
    }
}
