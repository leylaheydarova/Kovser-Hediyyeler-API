using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Bank:BaseEntity
    {
        public string Name { get; set; }

        //Relationships
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
    }
}
