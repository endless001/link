using System;
using Aliyun.OSS;
using Amazon.S3;
using StackExchange.Redis;
using Upload.API.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upload.API.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace Upload.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
            var identityUrl = configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                 {
                     options.Authority = identityUrl;
                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateAudience = false
                     };
                 });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "upload");
                });
            });

            return services;
        }
         

        public static IServiceCollection AddObjectStorageClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp =>
            {
                var config = configuration.GetSection("OssConfig").Get<OssConfig>();
                return new OssClient(config.Endpoint, config.AccessKeyId, config.AccessKeySecret);
            });

            services.AddSingleton(sp =>
            {
                var config = configuration.GetSection("OssConfig").Get<OssConfig>();
                return new AmazonS3Client(config.Endpoint, config.AccessKeyId, config.AccessKeySecret);
            });
            return services;
        }
        public static IServiceCollection AddObjectStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUploadService, OssUploadService>();
            services.AddSingleton<IUploadService, S3UploadService>();
            return services;
        }
        
       public static IServiceCollection AddObjectStorageFactory(this IServiceCollection services, IConfiguration configuration)
        {
            Dictionary<string, Func<IServiceProvider, IUploadService>> factory = new Dictionary<string, Func<IServiceProvider, IUploadService>>
            {
                { "S3" ,(provider) => provider.GetService<S3UploadService>() },
                { "OSS" ,(provider) => provider.GetService<OssUploadService>() }
            };

            services.AddSingleton(provider =>
            {
                Func<string, IUploadService> func = n => factory[n].Invoke(provider);
                return func;
            });
            return services;
        }
    }
}
