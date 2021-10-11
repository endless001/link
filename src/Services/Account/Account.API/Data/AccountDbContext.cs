using Account.API.EntityConfigurations;
using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Data
{
    public class AccountDbContext: DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
             : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountEntityTypeConfiguration());

        }
        public DbSet<AccountModel> Accounts { get; set; }
 
    }
}
