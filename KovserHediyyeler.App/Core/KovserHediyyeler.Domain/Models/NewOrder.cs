using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class NewOrder:BaseEntity
    {
        public Category Category { get; set; }
        public Department Department { get; set; }
        //public Product Product { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        public ICollection<Color> Colors { get; set; }
    }
}
