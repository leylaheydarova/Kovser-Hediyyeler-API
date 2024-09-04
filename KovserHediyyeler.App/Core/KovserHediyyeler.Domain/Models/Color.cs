using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        //Relationships
        public ICollection<ProductProperty> Properties {  get; set; }
        public ICollection<NewOrder> NewOrders { get; set; }
    }
}
