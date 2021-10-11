using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Message.API.Configuration;
using Message.API.Grpc;
using Message.API.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace Message.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<ISMSService>(sp =>
            {
                var config = Configuration.GetSection("SMSService:Tencent").Get<TencentSMSConfig>();
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                return new TencentSMSService(factory, config);
            });

            services.AddSingleton<IMailService>(sp =>
            {
                var config = Configuration.GetSection("Mail").Get<MailConfig>();
                var credentials = new NetworkCredential(config.UserName, config.Password);
                var factory = new SmtpClient()
                {
                    Port = config.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = config.Host,
                    EnableSsl = true,
                    Credentials = credentials,
                    Timeout = 3 * 1000
                };
                return new MailService(factory, config);
            });
            services.AddGrpc();
            services.AddControllers();
            services.AddHealthChecks().
                AddCheck("self", () => HealthCheckResult.Healthy());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
            app.UseRouting();
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
                endpoints.MapGrpcService<MessageGrpcService>();

            });
        }
    }
}
