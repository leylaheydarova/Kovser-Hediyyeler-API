using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class File:BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public StorageType StorageType { get; set; }
        [NotMapped]
        public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
        public override DateTime? DeletedAt { get => base.DeletedAt; set => base.DeletedAt = value; }
        public override bool isDeleted { get => base.isDeleted; set => base.isDeleted = value; }
    }
}
