using System.Reflection;
using Identity.EntityFramework.Configuration.Configuration;
using Identity.EntityFramework.MySql;
using MySqlMigrationAssembly = Identity.EntityFramework.MySql.Helpers.MigrationAssembly;

namespace Identity.Migration.Generate.Configuration.Database;

public static class MigrationAssemblyConfiguration
{
    public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
    {
        return databaseProvider.ProviderType switch
        {
            DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}