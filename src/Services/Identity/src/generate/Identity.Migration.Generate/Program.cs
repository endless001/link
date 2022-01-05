using Identity.Administration.DependencyInjection.Extensions;
using Identity.Administration.Options;
using Identity.EntityFramework.Shared.DbContexts;
using Identity.Migration.Generate.Configuration.Database;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityAdmin<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext,
    LogDbContext, IdentityServerDataProtectionDbContext>(ConfigureOptions);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 
app.UseAuthorization();

app.MapControllers();

app.Run();



void ConfigureOptions(IdentityAdminOptions options)
{
    // Applies configuration from appsettings.
    options.BindConfiguration(configuration);
   
    // Set migration assembly for application of db migrations
    var migrationsAssembly = MigrationAssemblyConfiguration.GetMigrationAssemblyByProvider(options.DatabaseProvider);
    options.DatabaseMigrations.SetMigrationsAssemblies(migrationsAssembly);

    // Use production DbContexts and auth services.
    options.Testing.IsStaging = false;
}