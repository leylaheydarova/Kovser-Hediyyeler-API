namespace KovserHedieyyeler.Application.Exceptions.FailExceptions
{
    public class PasswordChangeFailedException : BaseException
    {
        public PasswordChangeFailedException() : base("Şifrə yenilənməsində xəta baş verdi!")
        {
        }

        public PasswordChangeFailedException(string message) : base(message)
        {
        }

        public PasswordChangeFailedException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
