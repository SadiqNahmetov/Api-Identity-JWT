using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SoftDeleted).HasDefaultValue(false);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.UtcNow);

            builder.HasQueryFilter(m => !m.SoftDeleted);
        }
    }
}
