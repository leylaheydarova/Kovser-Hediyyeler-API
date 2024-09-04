using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class BasketItem:BaseEntity
    {
        public Product Product { get; set; }
        public Basket Basket { get; set; }
        public int ProductCount { get; set; }
    }
}
