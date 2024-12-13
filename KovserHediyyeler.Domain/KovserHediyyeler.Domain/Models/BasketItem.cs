using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class BasketItem : BaseEntity
    {
        public int ProductCount { get; set; }
        public bool isSelected { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Basket))]
        public Guid BasketID { get; set; }
        public Basket Basket { get; set; }

    }
}
