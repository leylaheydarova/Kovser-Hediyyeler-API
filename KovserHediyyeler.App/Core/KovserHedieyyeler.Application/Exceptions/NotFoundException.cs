using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException() : base("İstifadəçi adı və ya şifrə yanlışdır.")
        {   
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            
        }
    }
}
