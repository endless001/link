using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.SqlServer.Factories
{
    public class IdentityServerConfigurationDbContextFactory : IDesignTimeDbContextFactory<IdentityServerConfigurationDbContext>
    {
        public IdentityServerConfigurationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>();

            optionsBuilder.UseSqlServer("",
                        sqlOptions =>
                        {
                        });

            return new IdentityServerConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());
        }
    }
    
}
