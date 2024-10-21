using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Shipping : BaseEntity
    {
        public ShippingType ShippingType { get; set; }

        //Relationships
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
