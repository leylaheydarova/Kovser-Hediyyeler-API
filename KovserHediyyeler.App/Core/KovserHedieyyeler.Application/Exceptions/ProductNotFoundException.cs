using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class ProductNotFoundException:NotFoundException
    {
        public ProductNotFoundException() : base("Məhsul tapılmadı!")
        {
        }
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
