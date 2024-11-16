using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.BadRequestExceptions
{
    public class InvalidInputException : BaseException
    {
        public InvalidInputException(string input) : base($"Invalid {input} input")
        {
        }
    }
}
