using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductColor : BaseEntity
    {
        public string ColorName { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
