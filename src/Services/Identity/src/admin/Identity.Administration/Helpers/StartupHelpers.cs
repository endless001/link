using System.Globalization;
using Identity.Administration.ApplicationParts;
using Identity.Administration.Configuration;
using Identity.Administration.Constants;
using Identity.Administration.ExceptionHandling;
using Identity.Administration.Localization;
using Identity.Administration.Middlewares;
using Identity.EntityFramework.Configuration.Configuration;
using Identity.EntityFramework.Configuration.MySql;
using Identity.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Identity.EntityFramework.Configuration.PostgreSQL;
using Identity.EntityFramework.Configuration.SqlServer;
using Identity.EntityFramework.Shared.DbContexts;
using Identity.Shared.Configuration.Authentication;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Administration.Helpers;

public static class StartupHelpers
{
    internal class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                // Adds our required middlewares to the beginning of the app pipeline.
                // This does not include the middleware that is required to go between UseRouting and UseEndpoints.
 

                next(builder);

                // Routing-dependent middleware needs to go in between UseRouting and UseEndpoints and therefore 
                // needs to be handled by the user using UseIdentityServer4AdminUI().
            };
        }
    }


    public static void RegisterDbContexts<TConfigurationDbContext, TPersistedGrantDbContext,
        TLogDbContext, TDataProtectionDbContext>(
        this IServiceCollection services,
        ConnectionStringsConfiguration connectionStrings,
        DatabaseProviderConfiguration databaseProvider,
        DatabaseMigrationsConfiguration databaseMigrations)
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        where TLogDbContext : DbContext, ILogDbContext
        where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext
    {
        switch (databaseProvider.ProviderType)
        {
            case DatabaseProviderType.SqlServer:
                services
                    .RegisterSqlServerDbContexts<TConfigurationDbContext, TPersistedGrantDbContext,
                        TLogDbContext, TDataProtectionDbContext>(connectionStrings,
                        databaseMigrations);
                break;
            case DatabaseProviderType.PostgreSQL:
                services
                    .RegisterNpgSqlDbContexts<TConfigurationDbContext, TPersistedGrantDbContext,
                        TLogDbContext, TDataProtectionDbContext>(connectionStrings,
                        databaseMigrations);
                break;
            case DatabaseProviderType.MySql:
                services
                    .RegisterMySqlDbContexts<TConfigurationDbContext,
                        TPersistedGrantDbContext, TLogDbContext, TDataProtectionDbContext>(connectionStrings,
                        databaseMigrations);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(databaseProvider.ProviderType),
                    $@"The value needs to be one of {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderType)))}.");
        }
    }

    public static void RegisterDbContextsStaging<TConfigurationDbContext, TPersistedGrantDbContext,
        TLogDbContext, TDataProtectionDbContext>(this IServiceCollection services)
        where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
        where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        where TLogDbContext : DbContext, ILogDbContext
        where TDataProtectionDbContext : DbContext
    {
        var persistedGrantsDatabaseName = Guid.NewGuid().ToString();
        var configurationDatabaseName = Guid.NewGuid().ToString();
        var logDatabaseName = Guid.NewGuid().ToString();
        var identityDatabaseName = Guid.NewGuid().ToString();
        var auditLoggingDatabaseName = Guid.NewGuid().ToString();
        var dataProtectionDatabaseName = Guid.NewGuid().ToString();

        var operationalStoreOptions = new OperationalStoreOptions();
        services.AddSingleton(operationalStoreOptions);

        var storeOptions = new ConfigurationStoreOptions();
        services.AddSingleton(storeOptions);


        services.AddDbContext<TPersistedGrantDbContext>(optionsBuilder =>
            optionsBuilder.UseInMemoryDatabase(persistedGrantsDatabaseName));
        services.AddDbContext<TConfigurationDbContext>(optionsBuilder =>
            optionsBuilder.UseInMemoryDatabase(configurationDatabaseName));
        services.AddDbContext<TLogDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase(logDatabaseName));
        services.AddDbContext<LogDbContext>(optionsBuilder =>
            optionsBuilder.UseInMemoryDatabase(auditLoggingDatabaseName));
        services.AddDbContext<TDataProtectionDbContext>(optionsBuilder =>
            optionsBuilder.UseInMemoryDatabase(dataProtectionDatabaseName));
    }

    public static void ConfigureLocalization(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
    }

    public static void AddAuthorizationPolicies(this IServiceCollection services, AdminConfiguration adminConfiguration,
        Action<AuthorizationOptions> authorizationAction)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                policy => policy.RequireRole(adminConfiguration.AdministrationRole));

            authorizationAction?.Invoke(options);
        });
    }

    public static void AddMvcExceptionFilters(this IServiceCollection services)
    {
        //Exception handling
       // services.AddScoped<ControllerExceptionFilterAttribute>();
    }

    public static void AddMvcWithLocalization
        (this IServiceCollection services, CultureConfiguration cultureConfiguration)

    {
        services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

        services.AddLocalization(opts => { opts.ResourcesPath = ConfigurationConsts.ResourcesPath; });

        services.TryAddTransient(typeof(IGenericControllerLocalizer<>), typeof(GenericControllerLocalizer<>));

        services.AddTransient<IViewLocalizer, ResourceViewLocalizer>();

        services.AddControllersWithViews(o => { o.Conventions.Add(new GenericControllerRouteConvention()); })

            .AddViewLocalization(
                LanguageViewLocationExpanderFormat.Suffix,
                opts => { opts.ResourcesPath = ConfigurationConsts.ResourcesPath; })
            .AddDataAnnotationsLocalization()
            .ConfigureApplicationPartManager(m => { });

        services.Configure<RequestLocalizationOptions>(
            opts =>
            {
                // If cultures are specified in the configuration, use them (making sure they are among the available cultures),
                // otherwise use all the available cultures
                var supportedCultureCodes =
                    (cultureConfiguration?.Cultures?.Count > 0
                        ? cultureConfiguration.Cultures.Intersect(CultureConfiguration.AvailableCultures)
                        : CultureConfiguration.AvailableCultures).ToArray();

                if (!supportedCultureCodes.Any()) supportedCultureCodes = CultureConfiguration.AvailableCultures;
                var supportedCultures = supportedCultureCodes.Select(c => new CultureInfo(c)).ToList();

                // If the default culture is specified use it, otherwise use CultureConfiguration.DefaultRequestCulture ("en")
                var defaultCultureCode = string.IsNullOrEmpty(cultureConfiguration?.DefaultCulture)
                    ? CultureConfiguration.DefaultRequestCulture
                    : cultureConfiguration?.DefaultCulture;

                // If the default culture is not among the supported cultures, use the first supported culture as default
                if (!supportedCultureCodes.Contains(defaultCultureCode))
                    defaultCultureCode = supportedCultureCodes.FirstOrDefault();

                opts.DefaultRequestCulture = new RequestCulture(defaultCultureCode);
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
            });
    }

    public static void AddAuthenticationServicesStaging(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public static void AddAuthenticationServices(this IServiceCollection services,
        AdminConfiguration adminConfiguration,
        Action<AuthenticationBuilder> authenticationBuilderAction)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            options.Secure = CookieSecurePolicy.SameAsRequest;
            options.OnAppendCookie = cookieContext =>
                AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            options.OnDeleteCookie = cookieContext =>
                AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
        });

        var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;

                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options => { options.Cookie.Name = adminConfiguration.IdentityAdminCookieName; })
            .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
            {
                options.Authority = adminConfiguration.IdentityServerBaseUrl;
                options.RequireHttpsMetadata = adminConfiguration.RequireHttpsMetadata;
                options.ClientId = adminConfiguration.ClientId;
                options.ClientSecret = adminConfiguration.ClientSecret;
                options.ResponseType = adminConfiguration.OidcResponseType;

                options.Scope.Clear();
                foreach (var scope in adminConfiguration.Scopes)
                {
                    options.Scope.Add(scope);
                }

                options.ClaimActions.MapJsonKey(adminConfiguration.TokenValidationClaimRole,
                    adminConfiguration.TokenValidationClaimRole, adminConfiguration.TokenValidationClaimRole);

                options.SaveTokens = true;

                options.GetClaimsFromUserInfoEndpoint = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = adminConfiguration.TokenValidationClaimName,
                    RoleClaimType = adminConfiguration.TokenValidationClaimRole
                };

                options.Events = new OpenIdConnectEvents
                {
                    OnMessageReceived = context => OnMessageReceived(context, adminConfiguration),
                    OnRedirectToIdentityProvider = context => OnRedirectToIdentityProvider(context, adminConfiguration)
                };
            });

        authenticationBuilderAction?.Invoke(authenticationBuilder);
    }

    private static Task OnMessageReceived(MessageReceivedContext context, AdminConfiguration adminConfiguration)
    {
        context.Properties.IsPersistent = true;
        context.Properties.ExpiresUtc =
            new DateTimeOffset(DateTime.Now.AddHours(adminConfiguration.IdentityAdminCookieExpiresUtcHours));

        return Task.FromResult(0);
    }

    private static Task OnRedirectToIdentityProvider(RedirectContext n, AdminConfiguration adminConfiguration)
    {
        n.ProtocolMessage.RedirectUri = adminConfiguration.IdentityAdminRedirectUri;

        return Task.FromResult(0);
    }
   
    public static void UseRoutingDependentMiddleware(this IApplicationBuilder app, TestingConfiguration testingConfiguration)
    {
        app.UseAuthentication();
        if (testingConfiguration.IsStaging)
        {
            app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
        }

        app.UseAuthorization();
    }
}