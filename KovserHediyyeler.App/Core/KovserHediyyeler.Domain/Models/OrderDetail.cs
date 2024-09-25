using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class OrderDetail:BaseEntity
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        //Relationships
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid? DiscountID { get; set; }
        public Discount? Discount { get; set; }

       
    }
}
