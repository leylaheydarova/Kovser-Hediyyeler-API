using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class CustomerBankCard:BaseEntity
    {
        public string CardNumber { get; set; }
        public DateTime ExpireMonth { get; set; }
        public DateTime ExpireYear { get; set; }
        public string CVV { get; set; }

        //Relationships
        [ForeignKey(nameof(WebUser))]
        public Guid CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public Guid BankID { get; set; }
        public Bank Bank { get; set; }
    }
}
