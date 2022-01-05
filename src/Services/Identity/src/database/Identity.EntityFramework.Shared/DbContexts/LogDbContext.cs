using Identity.EntityFramework.DbContexts;
using Identity.EntityFramework.Entities;
using Identity.EntityFramework.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework.Shared.DbContexts;

public class LogDbContext: DbContext, ILogDbContext
{
    public DbSet<Log> Logs { get; set; }
    
    public LogDbContext(DbContextOptions<LogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ConfigureLogContext(builder);
    }

    private void ConfigureLogContext(ModelBuilder builder)
    {
        builder.Entity<Log>(log =>
        {
            log.ToTable(TableConsts.Logging);
            log.HasKey(x => x.Id);
            log.Property(x => x.Level).HasMaxLength(128);
        });
    }
}