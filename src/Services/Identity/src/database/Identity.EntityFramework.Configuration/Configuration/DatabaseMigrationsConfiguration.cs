namespace Identity.EntityFramework.Configuration.Configuration;

public class DatabaseMigrationsConfiguration
{
    public bool ApplyDatabaseMigrations { get; set; } = false;

    public string ConfigurationDbMigrationsAssembly { get; set; }

    public string PersistedGrantDbMigrationsAssembly { get; set; }

    public string LogDbMigrationsAssembly { get; set; }
    public string DataProtectionDbMigrationsAssembly { get; set; }

    public void SetMigrationsAssemblies(string commonMigrationsAssembly)
    {
        LogDbMigrationsAssembly = commonMigrationsAssembly;
        ConfigurationDbMigrationsAssembly = commonMigrationsAssembly;
        DataProtectionDbMigrationsAssembly = commonMigrationsAssembly;
        PersistedGrantDbMigrationsAssembly = commonMigrationsAssembly;
    }
}