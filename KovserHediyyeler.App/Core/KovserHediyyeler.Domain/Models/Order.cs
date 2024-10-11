using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double SavingAmount { get; set; }
        public double? TaxAmount { get; set; } //edv

        //Relationships
        public Guid OrderPaymentID { get; set; }
        public OrderPayment OrderPayment { get; set; }
        public Guid InvoiceFileId { get; set; }
        public InvoiceFile InvoiceFile { get; set; }
        public OrderStatus OrderStatus {  get; set; }
        [ForeignKey(nameof(Customer))]
        public Guid CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public Guid ShippingID { get; set; }
        public Shipping Shipping { get; set; }
        public Guid ShopID { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

    }
}
