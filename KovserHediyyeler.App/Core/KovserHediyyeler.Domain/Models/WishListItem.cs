using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class WishListItem:BaseEntity
    {
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public string WishListID { get; set; }
        public WishList List { get; set; }
    }
}
