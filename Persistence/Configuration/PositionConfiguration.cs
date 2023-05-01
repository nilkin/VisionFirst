using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.DepartmentId).IsRequired();

            builder.Property(a => a.DateOfEntry).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(p => p.LeaveDay)
                    .WithOne(ld => ld.Position)
                    .HasForeignKey<LeaveDay>(ld => ld.PositionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
