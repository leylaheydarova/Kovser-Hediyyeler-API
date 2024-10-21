using KovserHediyyeler.Domain.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Basket:BaseEntity
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<WebUser> Customer { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
