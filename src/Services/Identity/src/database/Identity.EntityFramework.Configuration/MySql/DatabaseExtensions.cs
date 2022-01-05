namespace Identity.EntityFramework.Configuration.MySql;

public static class DatabaseExtensions
{
     public static void RegisterMySqlDbContexts<TIdentityDbContext, TConfigurationDbContext,
            TPersistedGrantDbContext, TLogDbContext, TAuditLoggingDbContext, TDataProtectionDbContext, TAuditLog>(this IServiceCollection services,
            ConnectionStringsConfiguration connectionStrings,
            DatabaseMigrationsConfiguration databaseMigrations)
            where TIdentityDbContext : DbContext
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TConfigurationDbContext : DbContext, IAdminConfigurationDbContext
            where TLogDbContext : DbContext, IAdminLogDbContext
            where TAuditLoggingDbContext : DbContext, IAuditLoggingDbContext<TAuditLog>
            where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext
            where TAuditLog : AuditLog
        {
            var migrationsAssembly = typeof(DatabaseExtensions).GetTypeInfo().Assembly.GetName().Name;

            // Config DB for identity
            services.AddDbContext<TIdentityDbContext>(options =>
                options.UseMySql(connectionStrings.IdentityDbConnection, ServerVersion.AutoDetect(connectionStrings.IdentityDbConnection), sql => sql.MigrationsAssembly(databaseMigrations.IdentityDbMigrationsAssembly ?? migrationsAssembly)));

            // Config DB from existing connection
            services.AddConfigurationDbContext<TConfigurationDbContext>(options =>
                options.ConfigureDbContext = b =>
                    b.UseMySql(connectionStrings.ConfigurationDbConnection, ServerVersion.AutoDetect(connectionStrings.ConfigurationDbConnection), sql => sql.MigrationsAssembly(databaseMigrations.ConfigurationDbMigrationsAssembly ?? migrationsAssembly)));

            // Operational DB from existing connection
            services.AddOperationalDbContext<TPersistedGrantDbContext>(options => options.ConfigureDbContext = b =>
                b.UseMySql(connectionStrings.PersistedGrantDbConnection, ServerVersion.AutoDetect(connectionStrings.PersistedGrantDbConnection), sql => sql.MigrationsAssembly(databaseMigrations.PersistedGrantDbMigrationsAssembly ?? migrationsAssembly)));

            // Log DB from existing connection
            services.AddDbContext<TLogDbContext>(options => options.UseMySql(connectionStrings.AdminLogDbConnection, ServerVersion.AutoDetect(connectionStrings.AdminLogDbConnection),
                optionsSql => optionsSql.MigrationsAssembly(databaseMigrations.AdminLogDbMigrationsAssembly ?? migrationsAssembly)));

            // Audit logging connection
            services.AddDbContext<TAuditLoggingDbContext>(options => options.UseMySql(connectionStrings.AdminAuditLogDbConnection, ServerVersion.AutoDetect(connectionStrings.AdminAuditLogDbConnection),
                optionsSql => optionsSql.MigrationsAssembly(databaseMigrations.AdminAuditLogDbMigrationsAssembly ?? migrationsAssembly)));

            // DataProtectionKey DB from existing connection
            if(!string.IsNullOrEmpty(connectionStrings.DataProtectionDbConnection))
                services.AddDbContext<TDataProtectionDbContext>(options => options.UseMySql(connectionStrings.DataProtectionDbConnection, ServerVersion.AutoDetect(connectionStrings.DataProtectionDbConnection),
                    optionsSql => optionsSql.MigrationsAssembly(databaseMigrations.DataProtectionDbMigrationsAssembly ?? migrationsAssembly)));
        }
}