using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Shipping : BaseEntity
    {
        public ShippingType ShippingType { get; set; }
        public ShippingStatus ShippingStatus { get; set; }
        public DateTime? ShippedDate { get; set; }

        //Relationships
        [ForeignKey(nameof(Order))]
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
    }
}
