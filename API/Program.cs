using System.Reflection.Metadata;
using System.Threading.RateLimiting;
using API.Extensions;
using API.Migrations;
using Domain.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.RateLimiting;
using NLog;
using Infrastructure;
using Application.Services;
using Application.Interfaces;
using Application.Email;
using Infrastructure.Email;
using Infrastructure.Services;
using Domain.Helpers;
using Authentication;
using Infrastructure.Email;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.AddSignalR();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();
builder.Services.AddSingleton<IFirebaseService, FirebaseService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.ConfigureFluentMigrator(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAuthenticationService();
builder.Services.ConfigureMapper();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureAwsS3();
builder.Services.AddAuthentication();

var instance =
    builder.Configuration.GetSection(nameof(EmailServiceConfiguration)).Get<EmailServiceConfiguration>() ??
    throw new Exception($"Missing config for {nameof(EmailServiceConfiguration)}");
builder.Services.AddSingleton(instance);

builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateConverter());
    });

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 20;
        opt.Window = TimeSpan.FromSeconds(60);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 10;
    });
});

var app = builder.Build();

app.UsePathBase("/be");
app.Use((context, next) =>
{
    context.Request.PathBase = "/be";
    return next();
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append(
        "Content-Security-Policy",
        "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; style-src 'self' 'unsafe-inline';"
    );
    await next();
});

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Chat hub removed - not needed for HR system

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseMiddleware<SwaggerAuthenticationMiddleware>();
app.UseMiddleware<RequestLockMiddleware>();

app.UseSwagger();
app.MapSwagger().RequireAuthorization();

app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/be/swagger/v1/swagger.json", "PMAC HR System API v1");
    s.RoutePrefix = string.Empty;
    s.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseAuthentication();
app.UseMiddleware<ExpiredOrMissedTokenMiddleware>();
app.UseMiddleware<SessionLimiterMiddleware>();
app.UseAuthorization();
app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("fixed");

app.MigrateDatabase(logger, builder.Configuration);
app.Run();
