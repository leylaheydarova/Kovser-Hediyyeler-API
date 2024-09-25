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
        public int ProductCount { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }
    }
}
