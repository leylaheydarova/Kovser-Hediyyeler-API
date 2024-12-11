using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class WishListItem : BaseEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid WishListID { get; set; }
        public WishList List { get; set; }
    }
}
