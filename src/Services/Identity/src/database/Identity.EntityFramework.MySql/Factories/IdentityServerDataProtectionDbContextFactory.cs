

using Identity.EntityFramework.Shared.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.MySql.Factories
{
    public class IdentityServerDataProtectionDbContextFactory: IDesignTimeDbContextFactory<IdentityServerDataProtectionDbContext>
    {
        public IdentityServerDataProtectionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityServerDataProtectionDbContext>();

            optionsBuilder.UseMySql("",
                        new MySqlServerVersion(new Version(8, 0, 16)),
                        sqlOptions =>
                        {
                        });

            return new IdentityServerDataProtectionDbContext(optionsBuilder.Options);
        }
    }
}
