using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.SqlServer.Factories
{
    public class IdentityServerPersistedGrantDbContextFactory : IDesignTimeDbContextFactory<IdentityServerPersistedGrantDbContext>
    {
        public IdentityServerPersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerPersistedGrantDbContext>();

            optionsBuilder.UseSqlServer("",
                        sqlOptions =>
                        {
                        });

            return new IdentityServerPersistedGrantDbContext(optionsBuilder.Options, new OperationalStoreOptions());
        }
    }
}
