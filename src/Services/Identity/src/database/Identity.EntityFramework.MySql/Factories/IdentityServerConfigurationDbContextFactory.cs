using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.MySql.Factories
{
    public class IdentityServerConfigurationDbContextFactory : IDesignTimeDbContextFactory<IdentityServerConfigurationDbContext>
    {
        public IdentityServerConfigurationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>();

            optionsBuilder.UseMySql("",
                        new MySqlServerVersion(new Version(8, 0, 16)),
                        sqlOptions =>
                        {
                        });

            return new IdentityServerConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());
        }
    }
}
