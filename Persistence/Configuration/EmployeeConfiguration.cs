using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.DateOfEntry).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(e => e.Position)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(e => e.PositionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Account)
                   .WithOne(e => e.Employee)
                   .HasForeignKey<Account>(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
