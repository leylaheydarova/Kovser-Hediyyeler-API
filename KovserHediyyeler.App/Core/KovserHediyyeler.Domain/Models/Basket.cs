using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;

namespace KovserHediyyeler.Domain.Models
{
    public class Basket:BaseEntity
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public Order Order { get; set; }
        public ICollection<WebUser> Customers { get; set; } = new List<WebUser>();   
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
