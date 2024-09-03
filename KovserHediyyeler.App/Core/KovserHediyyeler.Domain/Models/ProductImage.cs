using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductImage:BaseEntity
    {
        public string FileName { get; set; }
        public string FileURL { get; set; }
        
        //Relationships
        public Product Product { get; set; }
    }
}
