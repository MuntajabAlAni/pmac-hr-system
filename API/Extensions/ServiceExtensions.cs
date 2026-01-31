using System.Reflection;
using System.Text;
using Amazon;
using Amazon.S3;
using Authentication;
using FluentMigrator.Runner;
using Domain.Interfaces;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
                .ScanIn(Assembly.GetExecutingAssembly())
                .For.Migrations());

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureAuthenticationService(this IServiceCollection services) =>
        services.AddScoped<IAuthenticationService, AuthenticationService>();

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

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["secretKey"];

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "PMAC-HR System API", Version = "v1" });
            s.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        Name = "Bearer",
                    },
                    []
                }
            });
        });
    }
}
