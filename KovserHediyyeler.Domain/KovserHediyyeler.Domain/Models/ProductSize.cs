using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductSize : BaseEntity
    {
        public string SizeName { get; set; }
        [ForeignKey(nameof(Product))]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
