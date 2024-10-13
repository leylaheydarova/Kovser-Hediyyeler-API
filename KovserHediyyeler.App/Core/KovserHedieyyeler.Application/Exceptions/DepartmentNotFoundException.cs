using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class DepartmentNotFoundException:NotFoundException
    {
        public DepartmentNotFoundException():base("Şöbə tapılmadı")
        {
            
        }
        public DepartmentNotFoundException(string message):base(message)
        {
            
        }
    }
}
