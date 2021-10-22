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
    public class AccountDbContext : DbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly byte[] _encryptionKey = new  byte[]{182,113,50 ,214,209,88 ,182,226,169,47 ,223,197,143,164,147,85 };

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
             : base(options)
        {
            _encryptionProvider = new AesProvider(_encryptionKey);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseEncryption(_encryptionProvider);
            builder.ApplyConfiguration(new AccountEntityTypeConfiguration(_encryptionProvider));
        }

        public DbSet<AccountModel> Accounts { get; set; }
 
    }
}


