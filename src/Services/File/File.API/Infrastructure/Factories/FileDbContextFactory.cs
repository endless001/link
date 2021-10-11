using System;
using System.IO;
using System.Reflection;
using File.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace File.API.Infrastructure.Factories
{
    public class FileDbContextFactory : IDesignTimeDbContextFactory<FileContext>
    {
        public FileContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FileContext>();

            optionsBuilder.UseMySql(configuration.GetValue<string>("ConnectionString"),
                        new MySqlServerVersion(new Version(8, 0, 16)),
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        });

            return new FileContext(optionsBuilder.Options);
        }
    }
}
