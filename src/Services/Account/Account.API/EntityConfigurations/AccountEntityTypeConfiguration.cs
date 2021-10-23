using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Account.API.Infrastructure.Extensions;
using Account.API.Infrastructure.Providers;

namespace Account.API.EntityConfigurations
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<AccountModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AccountEntityTypeConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("account");
            builder.HasKey(a => a.AccountId);
            builder.Property(p => p.Password).Encrypted(_encryptionProvider);
        }
    }
}
