using Identity.BusinessLogic.Resources;
using Identity.BusinessLogic.Services;
using Identity.EntityFramework.DbContexts;
using Identity.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServicesExtensions
{
    public static IServiceCollection AddAdminServices<TDbContext>(
        this IServiceCollection services)
        where TDbContext : DbContext, IIdentityPersistedGrantDbContext, IIdentityConfigurationDbContext, ILogDbContext
    {

        return services.AddAdminServices<TDbContext, TDbContext, TDbContext>();
    }

    public static IServiceCollection AddAdminServices<TConfigurationDbContext, TPersistedGrantDbContext, TLogDbContext>(
        this IServiceCollection services)
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        where TLogDbContext : DbContext, ILogDbContext
    {
        //Repositories
        services.AddTransient<IClientRepository, ClientRepository<TConfigurationDbContext>>();
        services.AddTransient<IIdentityResourceRepository, IdentityResourceRepository<TConfigurationDbContext>>();
        services.AddTransient<IApiResourceRepository, ApiResourceRepository<TConfigurationDbContext>>();
        services.AddTransient<IApiScopeRepository, ApiScopeRepository<TConfigurationDbContext>>();
        services.AddTransient<IPersistedGrantRepository, PersistedGrantRepository<TPersistedGrantDbContext>>();
        services.AddTransient<ILogRepository, LogRepository<TLogDbContext>>();

        //Services
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IApiResourceService, ApiResourceService>();
        services.AddTransient<IApiScopeService, ApiScopeService>();
        services.AddTransient<IIdentityResourceService, IdentityResourceService>();
        services.AddTransient<IPersistedGrantService, PersistedGrantService>();
        services.AddTransient<ILogService, LogService>();

        //Resources
        services.AddScoped<IApiResourceServiceResources, ApiResourceServiceResources>();
        services.AddScoped<IApiScopeServiceResources, ApiScopeServiceResources>();
        services.AddScoped<IClientServiceResources, ClientServiceResources>();
        services.AddScoped<IIdentityResourceServiceResources, IdentityResourceServiceResources>();
        services.AddScoped<IPersistedGrantServiceResources, PersistedGrantServiceResources>();

        return services;
    }
}