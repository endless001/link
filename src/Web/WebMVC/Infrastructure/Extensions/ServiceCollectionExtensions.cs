using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using WebMVC.Infrastructure.Handlers;
using WebMVC.Infrastructure.Services;

namespace WebMVC.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddUrlGroup(new Uri(configuration["IdentityUrlHC"]), name: "identityapi-check", tags: new string[] { "identityapi" });

            return services;
        }

        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //register delegating handlers
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddTransient<HttpClientRequestIdDelegatingHandler>();

            //set 5 min as the lifetime for each HttpMessageHandler int the pool
            services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddHttpClient<IContactService, ContactService>()
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                 .AddHttpMessageHandler<HttpClientRequestIdDelegatingHandler>();

            return services;
        }
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var identityUrl = configuration.GetValue<string>("IdentityUrl");
            var callBackUrl = configuration.GetValue<string>("CallBackUrl");
            var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
               .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
               {
               
                   options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   options.Authority = identityUrl;
                   options.SignedOutRedirectUri = callBackUrl;
                   options.ClientId = "mvc";
                   options.ClientSecret = "secret";
                   options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                   options.SaveTokens = true;
                   options.GetClaimsFromUserInfoEndpoint = true;
                   options.RequireHttpsMetadata = false;
                   options.Scope.Add("openid");
                   options.Scope.Add("profile");
                
               });
            return services;
        }
    }
}
