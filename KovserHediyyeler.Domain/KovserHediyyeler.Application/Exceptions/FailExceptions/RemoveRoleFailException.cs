using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.FailExceptions
{
    public class RemoveRoleFailException : BaseException
    {
        public RemoveRoleFailException() : base("İstifadəçi rolu silinərkən xəta baş verdi!")
        {
        }

        public RemoveRoleFailException(string message) : base(message)
        {
        }
    }
}
