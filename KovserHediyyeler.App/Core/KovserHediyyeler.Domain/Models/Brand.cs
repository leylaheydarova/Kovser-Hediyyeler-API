using KovserHediyyeler.Domain.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }

        //Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
        [NotMapped]
        public string BrandImagePath = "~/Assets/Images/Brands";
    }
}
