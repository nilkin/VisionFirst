using Domain.Entities;
using Domain.Enums;
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
            builder.Property(a => a.Email);
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Role).HasDefaultValue(Role.User);

        }
    }
}
