using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Basket:BaseEntity
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
       // public double? DiscountedPrice { get; set; } 
        //public Order? Order { get; set; }
        [ForeignKey(nameof(Customer))]
        public string CustomerID { get; set; } 
        public WebUser Customer { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
