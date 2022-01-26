using System.Reflection;
using Identity.EntityFramework.Configuration.Configuration;
using Identity.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.EntityFramework.Configuration.SqlServer;

public static class DatabaseExtensions
{
    public static void RegisterSqlServerDbContexts<TConfigurationDbContext,
        TPersistedGrantDbContext, TLogDbContext, TDataProtectionDbContext>(
        this IServiceCollection services,
        ConnectionStringsConfiguration connectionStrings,
        DatabaseMigrationsConfiguration databaseMigrations)
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        where TLogDbContext : DbContext, ILogDbContext
        where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext
    {
        var migrationsAssembly = typeof(DatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;


        // Config DB from existing connection
        services.AddConfigurationDbContext<TConfigurationDbContext>(options => options.ConfigureDbContext = b =>
            b.UseSqlServer(connectionStrings.ConfigurationDbConnection,
                sql => sql.MigrationsAssembly(
                    databaseMigrations.ConfigurationDbMigrationsAssembly ?? migrationsAssembly)));

        // Operational DB from existing connection
        services.AddOperationalDbContext<TPersistedGrantDbContext>(options => options.ConfigureDbContext = b =>
            b.UseSqlServer(connectionStrings.PersistedGrantDbConnection,
                sql => sql.MigrationsAssembly(databaseMigrations.PersistedGrantDbMigrationsAssembly ??
                                              migrationsAssembly)));

        // Log DB from existing connection
        services.AddDbContext<TLogDbContext>(options => options.UseSqlServer(connectionStrings.LogDbConnection,
            optionsSql =>
                optionsSql.MigrationsAssembly(databaseMigrations.LogDbMigrationsAssembly ?? migrationsAssembly)));


        // DataProtectionKey DB from existing connection
        if (!string.IsNullOrEmpty(connectionStrings.DataProtectionDbConnection))
            services.AddDbContext<TDataProtectionDbContext>(options => options.UseSqlServer(
                connectionStrings.DataProtectionDbConnection,
                optionsSql =>
                    optionsSql.MigrationsAssembly(databaseMigrations.DataProtectionDbMigrationsAssembly ??
                                                  migrationsAssembly)));
    }

    public static void RegisterSqlServerDbContexts<TConfigurationDbContext,
        TPersistedGrantDbContext, TDataProtectionDbContext>(this IServiceCollection services, string configurationConnectionString,
        string persistedGrantConnectionString, string dataProtectionConnectionString)
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext
    {
        var migrationsAssembly = typeof(DatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;

        // Config DB from existing connection
        services.AddConfigurationDbContext<TConfigurationDbContext>(options => options.ConfigureDbContext = b =>
            b.UseSqlServer(configurationConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

        // Operational DB from existing connection
        services.AddOperationalDbContext<TPersistedGrantDbContext>(options => options.ConfigureDbContext = b =>
            b.UseSqlServer(persistedGrantConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

        // DataProtectionKey DB from existing connection
        services.AddDbContext<TDataProtectionDbContext>(options =>
            options.UseSqlServer(dataProtectionConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));
    }
}