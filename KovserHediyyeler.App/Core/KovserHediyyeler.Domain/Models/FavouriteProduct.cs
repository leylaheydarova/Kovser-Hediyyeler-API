using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class FavouriteProduct:BaseEntity
    {
        public ICollection<Product> Products { get; set; }
        [ForeignKey("Customer")]
        public WebUser Customer { get; set; }
    }
}
