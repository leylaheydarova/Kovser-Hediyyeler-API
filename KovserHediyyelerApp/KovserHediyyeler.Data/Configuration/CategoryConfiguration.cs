using KovserHediyyeler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x=>x.isDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.Createdat)
                .HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}
