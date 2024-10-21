using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductProperty:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
        //Relationships
        public Guid ProductID { get; set; }
        public Product Product { get; set; } 
        public ICollection<ColorCodeProductProperty> ColorCodeProductProperties { get; set; } = new List<ColorCodeProductProperty>();
    }
}
