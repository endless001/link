using System.Reflection;
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

            var migrationsAssembly = typeof(LogDbContextFactory).GetTypeInfo().Assembly.GetName().Name;
            var connectionStrings = "server=localhost;port=3306;database=identity;user=root;password=123456;Connect Timeout=1000;SslMode=none;AllowPublicKeyRetrieval=true";

            optionsBuilder.UseMySql(connectionStrings,
                        ServerVersion.AutoDetect(connectionStrings),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(migrationsAssembly);
                        });

            return new IdentityServerConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());
        }
    }
}
