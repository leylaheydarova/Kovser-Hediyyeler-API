using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class ShopNotFoundException:NotFoundException
    {
        public ShopNotFoundException() : base("Mağaza tapılmadı!")
        {
            
        }
        public ShopNotFoundException(string message) : base(message)
        {
            
        }
    }
}
