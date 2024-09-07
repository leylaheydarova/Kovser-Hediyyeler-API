using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Basket:BaseEntity
    {
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public string? DiscountID { get; set; }
        public Discount? Discount { get; set; }
        [ForeignKey(nameof(WebUser))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
