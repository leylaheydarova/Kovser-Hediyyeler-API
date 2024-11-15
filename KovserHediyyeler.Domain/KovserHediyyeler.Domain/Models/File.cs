using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public StorageType StorageType { get; set; }
        [NotMapped]
        public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
        [NotMapped]
        public override DateTime? DeletedAt { get => base.DeletedAt; set => base.DeletedAt = value; }
        [NotMapped]
        public override bool isDeleted { get => base.isDeleted; set => base.isDeleted = value; }
    }
}
