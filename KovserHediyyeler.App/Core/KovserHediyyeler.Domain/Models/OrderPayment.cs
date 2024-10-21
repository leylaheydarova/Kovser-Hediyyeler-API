using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;
namespace KovserHediyyeler.Domain.Models
{
    public class OrderPayment:BaseEntity
    {
        public DateTime? DueDate { get; set; } //Odenis ucun son tarix
        public DateTime? PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Currency {  get; set; }

        //Relationships
        public Order Order { get; set; }
    }
}
