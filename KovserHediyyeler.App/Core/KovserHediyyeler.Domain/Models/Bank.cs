using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }

        //Relationships
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
    }
}
