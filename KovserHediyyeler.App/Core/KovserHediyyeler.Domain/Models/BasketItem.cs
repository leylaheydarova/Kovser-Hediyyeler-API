using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class BasketItem:BaseEntity
    {
        public int ProductCount { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }
    }
}
