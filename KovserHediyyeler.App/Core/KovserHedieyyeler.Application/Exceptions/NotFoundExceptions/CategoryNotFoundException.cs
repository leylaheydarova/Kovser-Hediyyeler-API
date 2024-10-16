using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class CategoryNotFoundException : BaseException
    {
        public CategoryNotFoundException() : base("Kateqoriya tapılmadı!")
        {
        }

        public CategoryNotFoundException(string message) : base(message)
        {
        }
    }
}
