

using Identity.EntityFramework.Shared.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.MySql.Factories
{
    
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();

            optionsBuilder.UseMySql("",
                        new MySqlServerVersion(new Version(8, 0, 16)),
                        sqlOptions =>
                        {
                        });
            return new LogDbContext(optionsBuilder.Options);
        }
    }

}
