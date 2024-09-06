using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class WishList:BaseEntity
    {
        [ForeignKey(nameof(WebUser))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public ICollection<WishListItem> ListItems { get; set; }
    }
}
