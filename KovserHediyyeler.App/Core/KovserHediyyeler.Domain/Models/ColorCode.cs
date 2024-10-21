using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class ColorCode:BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        //Relationships
        public ICollection<ColorCodeProductProperty> ColorCodeProductProperties { get; set; } = new List<ColorCodeProductProperty>();
    }
}
