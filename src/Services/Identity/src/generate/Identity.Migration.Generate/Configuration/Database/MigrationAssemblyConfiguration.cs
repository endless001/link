using System.Reflection;
using Identity.EntityFramework.Configuration.Configuration;
using MySqlMigrationAssembly = Identity.EntityFramework.MySql.Helpers.MigrationAssembly;
using SqlServerMigrationAssembly = Identity.EntityFramework.SqlServer.Helpers.MigrationAssembly;


namespace Identity.Migration.Generate.Configuration.Database;

public static class MigrationAssemblyConfiguration
{
    public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
    {
        return databaseProvider.ProviderType switch
        {
            DatabaseProviderType.SqlServer => typeof(SqlServerMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
            DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}