using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
namespace KovserHediyyeler.Domain.Models
{
    public class WishList:BaseEntity
    {
       public ICollection<WebUser> WebUsers { get; set; }
        public ICollection<WishListItem> ListItems { get; set; }
    }
}
