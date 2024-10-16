using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.BadRequestExceptions
{
    public class BadRequestException:BaseException
    {
        public BadRequestException():base("Daxil edilən məlumatlarda yalnışlıq var!")
        {  
        }

        public BadRequestException(string message):base(message)
        {  
        }
    }
}
