using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.FailExceptions
{
    public class FailException : BaseException
    {
        public FailException() : base("Xəta baş verdi!")
        {
        }

        public FailException(string message) : base(message)
        {
        }
    }
}
