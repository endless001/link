using Contact.API.Configuration;
using Contact.API.Data;
using Contact.API.Infrastructure.Extensions;
using Contact.API.Infrastructure.Filters;
using Contact.API.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Contact.API
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
            services.AddScoped<ContactDbContext>();
            services.AddScoped<IContactBookRepository, ContactBookRepository>().
                AddScoped<IContactRequestRepository, ContactRequestRepository>().
                AddScoped<IGroupRepository, GroupRepository>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddControllers(options =>
            {
              options.Filters.Add(typeof(HttpGlobalExceptionFilter));
              options.Filters.Add(typeof(ValidateModelStateFilter));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.API", Version = "v1" });
            });
            services.AddCustomAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                  .RequireAuthorization("ApiScope"); 
            });
        }
    }
}
