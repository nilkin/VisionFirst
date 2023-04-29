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

            builder.HasOne(p => p.LeaveDay)
                    .WithOne(ld => ld.Position)
                    .HasForeignKey<LeaveDay>(ld => ld.PositionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
