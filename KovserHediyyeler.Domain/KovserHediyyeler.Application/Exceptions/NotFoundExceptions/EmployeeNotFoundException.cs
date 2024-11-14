using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class EmployeeNotFoundException : BaseException
    {
        public EmployeeNotFoundException() : base("İşçi tapılmadı!")
        {

        }

        public EmployeeNotFoundException(string message) : base(message)
        {

        }
    }
}
