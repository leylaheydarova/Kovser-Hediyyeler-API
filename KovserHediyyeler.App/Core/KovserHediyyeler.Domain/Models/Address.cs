using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Address:BaseEntity
    {
        public string Region { get; set; } // F.eg: "Yasamal", "Nizami", etc.
        public string Street { get; set; }
        public string Home { get; set; }
        public string PostalCode { get; set; } // F.eg: AZ1038

        //Relationships
        public Shop Shop { get; set; }
        public string EmployeID {  get; set; }
        public Employee Employee { get; set; }
        [ForeignKey(nameof(WebUser))]
        public string CustomerID {  get; set; }
        public WebUser Customer { get; set; }
    }
}
