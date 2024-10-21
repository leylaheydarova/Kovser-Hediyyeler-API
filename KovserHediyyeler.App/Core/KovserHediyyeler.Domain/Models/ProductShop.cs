using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductShop:BaseEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid ShopID { get; set; }
        public Shop Shop { get; set; }
    }
}
