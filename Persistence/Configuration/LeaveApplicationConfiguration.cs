using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LeaveApplicationConfiguration : IEntityTypeConfiguration<LeaveApplication>
    {
        public void Configure(EntityTypeBuilder<LeaveApplication> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Status).HasDefaultValue(LeaveStatus.Pending);
            builder.Property(a => a.LeaveStartTime).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.LeaveDuration).IsRequired();
            builder.Property(a => a.DateOfEntry).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(p => p.Employee)
                   .WithMany(ld => ld.LeaveApplications)
                   .HasForeignKey(la => la.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
