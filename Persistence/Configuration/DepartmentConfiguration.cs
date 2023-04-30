using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.ShortName).IsRequired();
            builder.Property(a => a.FullName).IsRequired();
            builder.Property(a => a.Record).HasColumnType("ntext").HasDefaultValue(null);
            builder.Property(a => a.DateOfEntry).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);

            builder.HasMany(d => d.Positions)
                   .WithOne(p => p.Department)
                   .HasForeignKey(p => p.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
