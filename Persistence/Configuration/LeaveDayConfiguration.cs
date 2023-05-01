using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LeaveDayConfiguration : IEntityTypeConfiguration<LeaveDay>
    {
        public void Configure(EntityTypeBuilder<LeaveDay> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Note).IsRequired();
            builder.Property(a => a.NumberOfDays).IsRequired();
            builder.Property(a => a.PositionId).IsRequired();

            builder.Property(a => a.EntryDate).HasColumnType("datetime2").HasDefaultValue(DateTime.UtcNow);

        }
    }
}
