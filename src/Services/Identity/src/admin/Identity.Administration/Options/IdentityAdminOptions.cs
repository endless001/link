using Identity.Administration.Configuration;
using Identity.Administration.Constants;
using Identity.EntityFramework.Configuration.Configuration;
using Identity.Shared.Configuration.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Administration.Options;

public class IdentityAdminOptions
{

	public TestingConfiguration Testing { get; set; } = new TestingConfiguration();

	public ConnectionStringsConfiguration ConnectionStrings { get; set; } = new ConnectionStringsConfiguration();

	public AdminConfiguration Admin { get; set; } = new AdminConfiguration();

	public DatabaseProviderConfiguration DatabaseProvider { get; set; } = new DatabaseProviderConfiguration();

	public DatabaseMigrationsConfiguration DatabaseMigrations { get; set; } = new DatabaseMigrationsConfiguration();


	public CultureConfiguration Culture { get; set; } = new CultureConfiguration();


	public Action<IdentityOptions> IdentityConfigureAction { get; set; } = options => { };

	public DataProtectionConfiguration DataProtection { get; set; } = new DataProtectionConfiguration();

	public AzureKeyVaultConfiguration AzureKeyVault { get; set; } = new AzureKeyVaultConfiguration();
	public SecurityConfiguration Security { get; set; } = new SecurityConfiguration();

	public HttpConfiguration Http { get; set; } = new HttpConfiguration();
	
	public Func<IServiceCollection, IHealthChecksBuilder> HealthChecksBuilderFactory { get; set; }

	public void BindConfiguration(IConfiguration configuration)
	{
		configuration.GetSection(nameof(TestingConfiguration)).Bind(Testing);
		configuration.GetSection(ConfigurationConsts.ConnectionStringsKey).Bind(ConnectionStrings);
		configuration.GetSection(nameof(AdminConfiguration)).Bind(Admin);
		configuration.GetSection(nameof(DatabaseProviderConfiguration)).Bind(DatabaseProvider);
		configuration.GetSection(nameof(DatabaseMigrationsConfiguration)).Bind(DatabaseMigrations);
		configuration.GetSection(nameof(CultureConfiguration)).Bind(Culture);
		configuration.GetSection(nameof(DataProtectionConfiguration)).Bind(DataProtection);
		configuration.GetSection(nameof(AzureKeyVaultConfiguration)).Bind(AzureKeyVault);
		IdentityConfigureAction = options => configuration.GetSection(nameof(IdentityOptions)).Bind(options);
		configuration.GetSection(nameof(SecurityConfiguration)).Bind(Security);
		configuration.GetSection(nameof(HttpConfiguration)).Bind(Http);
	}
}