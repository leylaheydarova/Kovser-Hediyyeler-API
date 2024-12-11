using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class ShopNotFoundException : BaseException
    {
        public ShopNotFoundException() : base("Mağaza tapılmadı!")
        {

        }
        public ShopNotFoundException(string message) : base(message)
        {

        }
    }
}
