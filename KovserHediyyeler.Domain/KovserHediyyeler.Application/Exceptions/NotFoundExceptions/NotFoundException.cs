using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.NotFoundExceptions
{
    public class NotFoundException : BaseException
    {

        public NotFoundException(string message) : base($"Təəssüf,{message} tapılmadı!")
        {
        }

        public NotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
