using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.FailExceptions
{
    public class PasswordChangeFailedException:BaseException
    {
        public PasswordChangeFailedException() : base("Şifrə yenilənməsində xəta baş verdi!")
        {
        }

        public PasswordChangeFailedException(string message) : base(message) 
        {
        }
    }
}
