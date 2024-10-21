using KovserHediyyeler.Domain.Models.BaseModels;
namespace KovserHediyyeler.Domain.Models
{
    public class WishList:BaseEntity
    {
       public ICollection<WebUser> WebUsers { get; set; }
        public ICollection<WishListItem> ListItems { get; set; }
    }
}
