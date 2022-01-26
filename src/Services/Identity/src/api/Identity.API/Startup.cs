using System.Reflection;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Identity.API.Configuration;
using Identity.API.Infrastructure.Extensions;
using Identity.API.Infrastructure.Devspaces;
using Identity.API.Infrastructure.GrantValidator;
using Identity.API.Infrastructure.Services;
using Identity.EntityFramework.Shared.DbContexts;

namespace Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

   
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IVerifyService, VerifyService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            services.AddIdentityServer<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext>(Configuration);
            services.AddRegisterDbContexts<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext, IdentityServerDataProtectionDbContext>(Configuration);

            services.AddSingleton(sp =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration.GetValue<string>("Redis:ConnectionString"), true);
                configuration.ResolveDns = true;
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
            services.AddGrpcServices();
            services.Configure<UrlsConfig>(Configuration.GetSection("urls"));
            services.AddControllersWithViews();
            services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                {
                    Predicate = r => r.Name.Contains("self")
                });

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
