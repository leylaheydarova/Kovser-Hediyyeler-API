using KovserHediyyeler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Addresses
{
    public class AddressGetDto
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; } // F.eg: "Yasamal", "Nizami", etc.
        public string Street { get; set; }
        public string Home { get; set; }
        public string PostalCode { get; set; } // F.eg: AZ1038
        public bool IsCurrentAddress { get; set; }
    }
}
