using Account.API.EntityConfigurations;
using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.Infrastructure.Providers;

namespace Account.API.Data
{
    public class AccountDbContext : DbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
             : base(options)
        {
          _encryptionProvider = new CustomEncryptionProvider();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AccountEntityTypeConfiguration(_encryptionProvider));
        }

        public DbSet<AccountModel> Accounts { get; set; }

    }
}


