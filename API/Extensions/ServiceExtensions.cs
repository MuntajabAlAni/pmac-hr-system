using System.Reflection;
using Amazon;
using Amazon.S3;
// using Authentication; // Removed - will integrate with SSO later
using FluentMigrator.Runner;
using Domain.Interfaces;
using LoggerService;
// using Microsoft.AspNetCore.Authentication.JwtBearer; // Removed
// using Microsoft.IdentityModel.Tokens; // Removed  
using Microsoft.OpenApi.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Application.Services;
using Application.Interfaces;
using Application.Mapping;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination")
                    .AllowCredentials());
        });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureFluentMigrator(this IServiceCollection services,
        IConfiguration configuration) => services.AddLogging(c =>
            c.AddFluentMigratorConsole())
        .AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddSqlServer2016().WithGlobalConnectionString(configuration
                    .GetConnectionString("sqlConnection"))
                .ScanIn(typeof(DapperContext).Assembly)
                .For.Migrations());

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    // Authentication removed - will integrate with external SSO later

    public static void ConfigureMapper(this IServiceCollection services) =>
        services.AddSingleton(MapperConfig.GetMapperConfigs());

    public static void ConfigureAwsS3(this IServiceCollection services)
    {
        services.AddSingleton<IAmazonS3>(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var section = config.GetSection("ObjectStorage");

            var region = RegionEndpoint.GetBySystemName(section["Region"] ?? "us-east-1");
            var useSsl = section.GetValue<bool>("StorageUseSSL");

            var s3Config = new AmazonS3Config
            {
                RegionEndpoint = region,
                UseHttp = !useSsl,
                ForcePathStyle = true
            };

            var accessKey = section["AccessKey"];
            var secretKey = section["SecretKey"];

            if (!string.IsNullOrWhiteSpace(accessKey) && !string.IsNullOrWhiteSpace(secretKey))
            {
                return new AmazonS3Client(accessKey, secretKey, s3Config);
            }

            return new AmazonS3Client(s3Config);
        });
    }

    // ConfigureJwt removed - will integrate with external SSO later

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "PMAC-HR System API", 
                Version = "v1",
                Description = "Iraqi Governmental HR Management System - Backend API (No Authentication)"
            });
            // Security definition removed - no authentication required
        });
    }
}
