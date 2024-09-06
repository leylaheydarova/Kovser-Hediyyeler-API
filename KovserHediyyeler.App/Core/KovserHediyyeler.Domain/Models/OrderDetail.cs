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
        public string OrderID { get; set; }
        public Order Order { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? DiscountID { get; set; }
        public Discount? Discount { get; set; }

        //Relationships
       
    }
}
