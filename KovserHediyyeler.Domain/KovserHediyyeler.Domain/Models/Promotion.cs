using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class Promotion : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
