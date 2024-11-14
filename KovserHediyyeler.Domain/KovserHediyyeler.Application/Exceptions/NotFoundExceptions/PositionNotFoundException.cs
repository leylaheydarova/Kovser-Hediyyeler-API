using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class PositionNotFoundException : BaseException
    {
        public PositionNotFoundException() : base("Vəzifə tapılmadı")
        {

        }

        public PositionNotFoundException(string message) : base(message)
        {

        }
    }
}
