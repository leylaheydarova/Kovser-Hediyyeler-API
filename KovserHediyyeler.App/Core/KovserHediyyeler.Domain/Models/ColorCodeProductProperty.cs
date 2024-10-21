using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class ColorCodeProductProperty:BaseEntity
    {
        public Guid ColorCodeID { get; set; }
        public ColorCode ColorCode { get; set; }
        public Guid ProductPropertyID { get; set; }
        public ProductProperty ProductProperty { get; set; }
    }
}
