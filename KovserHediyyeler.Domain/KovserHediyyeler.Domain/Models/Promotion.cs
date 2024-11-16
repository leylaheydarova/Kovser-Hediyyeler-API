using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Promotion : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DiscountPersentage? DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<ProductImageFile> Images { get; set; } = new List<ProductImageFile>();


        [NotMapped]
        public string PromotionPath = "~/Assets/Images/Departments";

    }
}
