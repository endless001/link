using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.MySql.Factories
{
    public class IdentityServerPersistedGrantDbContextFactory: IDesignTimeDbContextFactory<IdentityServerPersistedGrantDbContext>
    {
        public IdentityServerPersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerPersistedGrantDbContext>();

            optionsBuilder.UseMySql("",
                        new MySqlServerVersion(new Version(8, 0, 16)),
                        sqlOptions =>
                        {
                        });

            return new IdentityServerPersistedGrantDbContext(optionsBuilder.Options,new OperationalStoreOptions());
        }
    }
}
