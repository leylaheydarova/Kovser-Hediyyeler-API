using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class AddressNotFoundException : BaseException
    {
        public AddressNotFoundException() : base("Ünvan tapılmadı!")
        {
        }

        public AddressNotFoundException(string message) : base(message)
        {
        }
    }
}
