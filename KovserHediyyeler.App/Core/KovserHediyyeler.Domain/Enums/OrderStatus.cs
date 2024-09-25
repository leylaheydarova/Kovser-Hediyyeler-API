using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Enums
{
    public enum OrderStatus
    {
        SifarişAlındı = 1,
        MəhsulHazırlanır,
        MəhsulMağazadadır,
        KarqoyaVerildi,
        Çatdırıldı,
        İmtina,
        GeriQaytarıldı
    }
}
