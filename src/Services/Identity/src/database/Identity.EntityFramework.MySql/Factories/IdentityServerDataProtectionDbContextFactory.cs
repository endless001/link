

using Identity.EntityFramework.Shared.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Identity.EntityFramework.MySql.Factories
{
    public class IdentityServerDataProtectionDbContextFactory: IDesignTimeDbContextFactory<IdentityServerDataProtectionDbContext>
    {
        public IdentityServerDataProtectionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerDataProtectionDbContext>();
            var migrationsAssembly = typeof(LogDbContextFactory).GetTypeInfo().Assembly.GetName().Name;
            var connectionStrings = "server=localhost;port=3306;database=identity;user=root;password=123456;Connect Timeout=1000;SslMode=none;AllowPublicKeyRetrieval=true";

            optionsBuilder.UseMySql(connectionStrings,
                        ServerVersion.AutoDetect(connectionStrings),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(migrationsAssembly);
                        });

            return new IdentityServerDataProtectionDbContext(optionsBuilder.Options);
        }
    }
}
