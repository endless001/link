using Account.API.EntityConfigurations;
using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Data
{
    public class AccountDbContext: DbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly byte[] _encryptionKey = new byte[1];
        private readonly byte[] _encryptionIV = new byte[1];
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
             : base(options)
        {
            _encryptionProvider = new AesProvider(_encryptionKey, _encryptionIV);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseEncryption(_encryptionProvider);
            builder.ApplyConfiguration(new AccountEntityTypeConfiguration(_encryptionProvider));
        }

        public DbSet<AccountModel> Accounts { get; set; }
 
    }
}
