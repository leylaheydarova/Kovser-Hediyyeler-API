using KovserHedieyyeler.Application.Exceptions;

namespace KovserHediyyeler.Application.Exceptions.FailExceptions
{
    public class AddRoleFailException : BaseException
    {
        public AddRoleFailException() : base("İstifadəçiyə rol mənimsədilərkən xəta baş verdi!")
        {
        }

        public AddRoleFailException(string message) : base(message)
        {
        }
    }
}
