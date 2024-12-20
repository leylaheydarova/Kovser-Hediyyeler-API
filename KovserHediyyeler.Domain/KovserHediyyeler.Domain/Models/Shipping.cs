using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class Shipping : BaseEntity
    {
        public ShippingType ShippingType { get; set; }
        public ShippingStatus ShippingStatus { get; set; }
        public DateTime? ShippedDate { get; set; }

        //Relationships
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
    }
}
