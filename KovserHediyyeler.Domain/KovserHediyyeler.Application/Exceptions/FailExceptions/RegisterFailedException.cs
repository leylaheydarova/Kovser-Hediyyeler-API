using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.FailExceptions
{
    public class RegisterFailedException : BaseException
    {
        public RegisterFailedException() : base("Qeydiyyat zamanı gözlənilməz xəta baş verdi! Zəhmət olmasa şəbəkənizə və ya qeyd etdiyiniz məlumatların doğruluğunu yoxlayın.")
        {
        }

        public RegisterFailedException(string message) : base(message)
        {
        }
    }
}
