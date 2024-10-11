using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductImageFile:File
    {
        public bool IsMain { get; set; }
        public string FileName { get; set; }
        public string FileURL { get; set; }
        
        //Relationships
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
