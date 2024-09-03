using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductProperty:BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
        //Relationships
        public Product Product { get; set; }
    }
}
