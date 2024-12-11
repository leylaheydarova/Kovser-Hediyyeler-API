using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class PromotionNotFoundException : BaseException
    {
        public PromotionNotFoundException() : base("Doğru kampaniya məhsulu tapılmadı!") { }

        public PromotionNotFoundException(string message) : base(message) { }

    }
}
