using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Email).IsRequired();
            builder.Property(a => a.Password).IsRequired();

            builder.HasOne(a => a.Employee)
                   .WithOne(e => e.Account)
                   .HasForeignKey<Employee>(e => e.Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
