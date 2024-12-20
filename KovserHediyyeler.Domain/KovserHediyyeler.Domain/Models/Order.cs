using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double SavingAmount { get; set; }
        //public double? TaxAmount { get; set; } //edv
        public string OrderTrackingNumber { get; set; }

        //Relationships
        public OrderPayment? OrderPayment { get; set; }
        //public InvoiceFile? InvoiceFile { get; set; }
        public OrderStatus OrderStatus { get; set; }
        [ForeignKey(nameof(Customer))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public Shipping Shipping { get; set; }
        //public Guid? ShopID { get; set; }
        //public Shop? Shop { get; set; }
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}
