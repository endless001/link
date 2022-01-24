using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Identity.EntityFramework.MySql.Factories
{
    public class IdentityServerPersistedGrantDbContextFactory: IDesignTimeDbContextFactory<IdentityServerPersistedGrantDbContext>
    {
        public IdentityServerPersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerPersistedGrantDbContext>();
            var migrationsAssembly = typeof(LogDbContextFactory).GetTypeInfo().Assembly.GetName().Name;
            var connectionStrings = "server=localhost;port=3306;database=identity;user=root;password=123456;Connect Timeout=1000;SslMode=none;AllowPublicKeyRetrieval=true";

            optionsBuilder.UseMySql(connectionStrings,
                     ServerVersion.AutoDetect(connectionStrings),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(migrationsAssembly);
                        });

            return new IdentityServerPersistedGrantDbContext(optionsBuilder.Options,new OperationalStoreOptions());
        }
    }
}
