using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class EmployeeNotFoundException:NotFoundException
    {
        public EmployeeNotFoundException():base("İşçi tapılmadı!")
        {
            
        }

        public EmployeeNotFoundException(string message) : base(message)
        {
            
        }
    }
}
