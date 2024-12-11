using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class UserNotFoundException:BaseException
    {
        public UserNotFoundException() : base("İstifadəçi tapılmadı!")
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
