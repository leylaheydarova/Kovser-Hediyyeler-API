using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class BrandNotFoundException:NotFoundException
    {
        public BrandNotFoundException() : base("Brend tapılmadı!")
        {
        }

        public BrandNotFoundException(string message) : base(message)
        {
        }
    }
}
