namespace KovserHediyyeler.Domain.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        virtual public DateTime? DeletedAt { get; set; }
        virtual public DateTime? UpdatedAt { get; set; }
        virtual public bool isDeleted { get; set; }
    }
}
