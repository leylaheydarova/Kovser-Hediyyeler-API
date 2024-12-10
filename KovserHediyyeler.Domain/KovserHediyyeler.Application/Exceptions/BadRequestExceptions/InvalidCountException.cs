using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.BadRequestExceptions
{
    public class InvalidCountException : BaseException
    {
        public InvalidCountException(int count) : base($"Təəssüf ki, stokda istədiyiniz qədər məhsul yoxdur. Maksimum say {count} qədər ola bilər. Əgər bu say sizə kifayət etmirsə, bildirişi aktivləşdirərək stok yenilənəndə məlumat ala bilərsiniz!")
        {
        }

        public InvalidCountException(string message) : base(message)
        {
        }
    }
}
