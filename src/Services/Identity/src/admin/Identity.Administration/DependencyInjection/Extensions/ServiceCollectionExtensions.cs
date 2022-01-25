using Identity.Administration.Helpers;
using Identity.Administration.Options;
using Identity.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Administration.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
   
    public static IServiceCollection AddIdentityAdmin<TIdentityServerDbContext, TPersistedGrantDbContext
            ,TDataProtectionDbContext, TLogDbContext>
        (this IServiceCollection services, Action<IdentityAdminOptions> optionsAction)
        where TIdentityServerDbContext : DbContext, IIdentityConfigurationDbContext
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TLogDbContext : DbContext, ILogDbContext
        where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext

    {
        // Builds the options from user preferences or configuration.
        var options = new IdentityAdminOptions();
        optionsAction(options);

        // Adds root configuration to the DI.
        services.AddSingleton(options.Admin);

        // Add DbContexts for Asp.Net Core Identity, Logging and IdentityServer - Configuration store and Operational store
        if (!options.Testing.IsStaging)
        {
            services.RegisterDbContexts< TIdentityServerDbContext,
                TPersistedGrantDbContext, TLogDbContext, TDataProtectionDbContext>(options.ConnectionStrings, options.DatabaseProvider,
                options.DatabaseMigrations);
        }
        else
        {
            services.RegisterDbContextsStaging<TIdentityServerDbContext,
                TPersistedGrantDbContext, TLogDbContext,
                TDataProtectionDbContext>();
        }

        // Add Asp.Net Core Identity Configuration and OpenIdConnect auth as well
        if (!options.Testing.IsStaging)
        {
            services.AddAuthenticationServices(options.Admin, options.Security.AuthenticationBuilderAction);
        }
        else
        {
            services.AddAuthenticationServicesStaging();
        }

        // Add HSTS options
        if (options.Security.UseHsts)
        {
            services.AddHsts(opt =>
            {
                opt.Preload = true;
                opt.IncludeSubDomains = true;
                opt.MaxAge = TimeSpan.FromDays(365);

                options.Security.HstsConfigureAction?.Invoke(opt);
            });
        }

        // Add exception filters in MVC
        services.AddMvcExceptionFilters();

        // Add all dependencies for IdentityServer Admin
        services.AddAdminServices<TIdentityServerDbContext, TPersistedGrantDbContext, TLogDbContext>();


        // Add all dependencies for Asp.Net Core Identity in MVC - these dependencies are injected into generic Controllers
        // Including settings for MVC and Localization


        // Add authorization policies for MVC
        services.AddAuthorizationPolicies(options.Admin, options.Security.AuthorizationConfigureAction);

   
        // Add health checks.
        var healthChecksBuilder = options.HealthChecksBuilderFactory?.Invoke(services) ?? services.AddHealthChecks();
     
        // Adds a startup filter for further middleware configuration.
        services.AddSingleton(options.Testing);
        services.AddSingleton(options.Security);
        services.AddSingleton(options.Http);
        services.AddTransient<IStartupFilter, StartupHelpers.StartupFilter>();

        return services;
    }
}