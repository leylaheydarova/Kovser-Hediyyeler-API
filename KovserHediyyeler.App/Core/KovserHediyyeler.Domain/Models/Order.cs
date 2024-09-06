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
        [ForeignKey(nameof(WebUser))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool isShipping {  get; set; }

        //Relationships
        public string ShopID { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<OrderDetail> Details { get; set; }

    }
}
