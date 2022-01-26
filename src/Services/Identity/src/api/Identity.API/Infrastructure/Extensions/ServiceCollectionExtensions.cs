using System;
using Identity.API.Configuration;
using Identity.API.Infrastructure.Constants;
using Identity.API.Infrastructure.Interceptors;
using Identity.EntityFramework.Configuration.Configuration;
using Identity.EntityFramework.Configuration.MySql;
using Identity.EntityFramework.Configuration.PostgreSQL;
using Identity.EntityFramework.Configuration.SqlServer;
using Identity.EntityFramework.DbContexts;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Account.API.Grpc.AccountGrpc;
using static Message.API.Grpc.MessageGrpc;

namespace Identity.API.Infrastructure.Extensions
{
    public  static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGrpcServices(this IServiceCollection services)
        {
            services.AddTransient<GrpcExceptionInterceptor>();

            services.AddGrpcClient<AccountGrpcClient>((services, options) =>
            {
                var url = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcAccount;
                options.Address = new Uri(url);
            }).AddInterceptor<GrpcExceptionInterceptor>();

            services.AddGrpcClient<MessageGrpcClient>((services, options) =>
            {
                var url = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcMessage;
                options.Address = new Uri(url);
            }).AddInterceptor<GrpcExceptionInterceptor>();

            return services;
        }

        public static IIdentityServerBuilder AddIdentityServer<TConfigurationDbContext, TPersistedGrantDbContext>(
           this IServiceCollection services,
           IConfiguration configuration)
           where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
           where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
        {
            
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

            }).AddConfigurationStore<TConfigurationDbContext>()
                .AddOperationalStore<TPersistedGrantDbContext>();
            return builder;
        }

        public static void AddRegisterDbContexts<TConfigurationDbContext, TPersistedGrantDbContext, TDataProtectionDbContext>(this IServiceCollection services, IConfiguration configuration)
             where TPersistedGrantDbContext : DbContext, IIdentityPersistedGrantDbContext
             where TConfigurationDbContext : DbContext, IIdentityConfigurationDbContext
             where TDataProtectionDbContext : DbContext, IDataProtectionKeyContext
        {

            var databaseProvider = configuration.GetSection(nameof(DatabaseProviderConfiguration)).Get<DatabaseProviderConfiguration>();

            var configurationConnectionString = configuration.GetConnectionString(ConfigurationConsts.ConfigurationDbConnectionStringKey);
            var persistedGrantsConnectionString = configuration.GetConnectionString(ConfigurationConsts.PersistedGrantDbConnectionStringKey);
            var dataProtectionConnectionString = configuration.GetConnectionString(ConfigurationConsts.DataProtectionDbConnectionStringKey);

            switch (databaseProvider.ProviderType)
            {
                case DatabaseProviderType.SqlServer:
                    services
                        .RegisterSqlServerDbContexts<TConfigurationDbContext, TPersistedGrantDbContext,
                             TDataProtectionDbContext>(configurationConnectionString,
                            persistedGrantsConnectionString, dataProtectionConnectionString);
                    break;
                case DatabaseProviderType.PostgreSQL:
                    services
                        .RegisterNpgSqlDbContexts<TConfigurationDbContext, TPersistedGrantDbContext,
                             TDataProtectionDbContext>(configurationConnectionString,
                            persistedGrantsConnectionString, dataProtectionConnectionString);
                    break;
                case DatabaseProviderType.MySql:
                    services
                        .RegisterMySqlDbContexts<TConfigurationDbContext,
                            TPersistedGrantDbContext, TDataProtectionDbContext>(configurationConnectionString,
                            persistedGrantsConnectionString, dataProtectionConnectionString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(databaseProvider.ProviderType),
                        $@"The value needs to be one of {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderType)))}.");
            }
        }

    }
}
 