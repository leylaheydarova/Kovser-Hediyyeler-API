using KovserHediyyeler.Domain.Models.BaseModel;

namespace KovserHediyyeler.Domain.Models
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }
    }
}
