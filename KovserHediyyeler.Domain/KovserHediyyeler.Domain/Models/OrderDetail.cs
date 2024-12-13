using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class OrderDetail : BaseEntity
    {
        public double Price { get; set; }//quantity * product.price
        public int Quantity { get; set; }
        //Relationships
        [ForeignKey(nameof(Order))]
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
