using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Address:BaseEntity
    {
        //public string Country {  get; set; }
        public string Region { get; set; } // F.eg: "Yasamal", "Nizami", etc.
        public string Street { get; set; }
        public string Home { get; set; }
        public string PostalCode { get; set; } // F.eg: AZ1038
    }
}
