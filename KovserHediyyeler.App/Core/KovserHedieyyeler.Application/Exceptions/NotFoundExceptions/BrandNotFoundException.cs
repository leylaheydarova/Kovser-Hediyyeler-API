using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class BrandNotFoundException : BaseException
    {
        public BrandNotFoundException() : base("Brend tapılmadı!")
        {
        }

        public BrandNotFoundException(string message) : base(message)
        {
        }
    }
}
