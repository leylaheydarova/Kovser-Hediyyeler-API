using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Bank:BaseEntity
    {
        public string Name { get; set; }

        //Relationships
        public ICollection<CustomerBankCard> BankCards { get; set; } = new List<CustomerBankCard>();
    }
}
//TODO: "Bank ilə ödəniş sistemini daha sonra artıracağamş Bu səbəblə, müvəqqəti olaraq ödəniş button üzərinə "Tezliklə ödəniş funksiyası gələcək" deyə yazılmalıdır."
//TODO: "Zaman qalarsa, qəbz sistemini artırmaq və file olaraq müştərinin əldə etməsini təmin etmək"