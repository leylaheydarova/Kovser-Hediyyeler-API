using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.FailExceptions
{
    public class AuthenticationErrorException:BaseException
    {
        public AuthenticationErrorException() : base("Doğrulama xətası!")
        {
        }

        public AuthenticationErrorException(string message) : base(message) 
        {
        }
    }
}
