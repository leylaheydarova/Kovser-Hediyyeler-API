using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class ColorCode : BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        //Relationships
        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
