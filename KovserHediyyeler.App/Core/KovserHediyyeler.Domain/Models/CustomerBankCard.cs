using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class CustomerBankCard:BaseEntity
    {
        public string CardNumber { get; set; }
        public DateTime ExpireMonth { get; set; }
        public DateTime ExpireYear { get; set; }
        public string CVV { get; set; }
        public bool IsForPayment { get; set; }

        //Relationships
        [ForeignKey(nameof(Customer))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
        public Guid BankID { get; set; }
        public Bank Bank { get; set; }
    }
}
