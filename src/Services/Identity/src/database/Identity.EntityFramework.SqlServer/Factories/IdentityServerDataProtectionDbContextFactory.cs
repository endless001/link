
using Identity.EntityFramework.Shared.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.SqlServer.Factories
{
    public class IdentityServerDataProtectionDbContextFactory : IDesignTimeDbContextFactory<IdentityServerDataProtectionDbContext>
    {
        public IdentityServerDataProtectionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerDataProtectionDbContext>();

            optionsBuilder.UseSqlServer("",
                        sqlOptions =>
                        {
                        });

            return new IdentityServerDataProtectionDbContext(optionsBuilder.Options);
        }
    }
}
