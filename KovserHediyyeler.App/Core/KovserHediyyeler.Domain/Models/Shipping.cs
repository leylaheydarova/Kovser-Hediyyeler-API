using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Shipping : BaseEntity
    {
        public ShippingType ShippingType { get; set; }

        //Relationships
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
