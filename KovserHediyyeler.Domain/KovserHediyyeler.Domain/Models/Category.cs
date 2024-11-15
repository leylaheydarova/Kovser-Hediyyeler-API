using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public Guid? ParentId { get; set; }
        public Category? ParentCategory { get; set; }

        //Relations
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
