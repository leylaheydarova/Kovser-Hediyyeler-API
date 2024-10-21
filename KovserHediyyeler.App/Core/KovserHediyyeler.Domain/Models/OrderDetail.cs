using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class OrderDetail:BaseEntity
    {
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DiscountPersentage DiscountPersentage { get; set; }
        //Relationships
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }       
    }
}
