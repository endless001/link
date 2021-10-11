using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Account.API.Infrastructure.Extensions;

namespace Account.API.EntityConfigurations
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("account");
            builder.HasKey(a => a.AccountId);

            builder.Property(p => p.Password).HasConversion(
               val => val.Encrypt(),
               val => val.Decrypt());
        }
    }
}
