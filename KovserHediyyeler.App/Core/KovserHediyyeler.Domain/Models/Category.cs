using KovserHediyyeler.Domain.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid? ParentId { get; set; }
        public Category? ParentCategory { get; set; }

        //Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();

        //Cross-Tables
        public ICollection<CategoryDepartment> CategoryDepartments { get; set; } = new List<CategoryDepartment>();
        public ICollection<CategoryPromotion> CategoryPromotions { get; set; } = new List<CategoryPromotion>();

    }
}
