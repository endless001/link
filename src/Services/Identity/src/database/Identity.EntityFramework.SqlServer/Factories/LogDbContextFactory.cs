
using Identity.EntityFramework.Shared.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.EntityFramework.SqlServer.Factories
{
    public class LogDbContextFactory : IDesignTimeDbContextFactory<LogDbContext>
    {
        public LogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LogDbContext>();

            optionsBuilder.UseSqlServer("",
                        sqlOptions =>
                        {
                        });
            return new LogDbContext(optionsBuilder.Options);
        }
    }
}
