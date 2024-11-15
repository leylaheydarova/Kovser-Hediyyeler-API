using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductProperty : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        //Relationships
        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public ICollection<ColorCode> Colors { get; set; } = new List<ColorCode>();
    }
}
