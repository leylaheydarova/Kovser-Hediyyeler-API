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
        public bool isPaid {  get; set; }

        //Relationships
        [ForeignKey(nameof(WebUser))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public string ShippingID { get; set; }
        public Shipping Shipping { get; set; }
        public string ShopID { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<OrderDetail> Details { get; set; }

    }
}
