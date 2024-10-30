using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace KovserHediyyeler.Domain.Models
{
    public class WishList:BaseEntity
    {
        [ForeignKey(nameof(Customer))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public ICollection<WishListItem> ListItems { get; set; }
    }
}
