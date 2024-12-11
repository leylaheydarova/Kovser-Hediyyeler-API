using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException() : base("Məhsul tapılmadı!")
        {
        }
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
