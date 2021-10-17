using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.API.Infrastructure.Extensions;
using Chat.API.Infrastructure.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chat.API.Configuration;
using Chat.API.Data;
using StackExchange.Redis;

namespace Chat.API
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

            services.Configure<MongoConnection>(Configuration.GetSection("MongoConnection"));
            services.AddScoped<ChatDbContext>();
            services.AddScoped<IRecordRepository, RecordRepository>();

            services.AddSignalR()
                .AddStackExchangeRedis(Configuration.GetValue<string>("Redis:ConnectionString"), options =>
                {
                    options.Configuration.ChannelPrefix = "Chat";
                });
            services.AddControllers();
            services.AddCustomAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hub");
                endpoints.MapControllers()
                .RequireAuthorization("ApiScope");
            });

            }
    }
}
