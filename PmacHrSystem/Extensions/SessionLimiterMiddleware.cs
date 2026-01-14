using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Entities.ErrorModel;
using Interfaces;

namespace PmacHrSystem.Extensions;

public class SessionLimiterMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
{
    public async Task InvokeAsync(HttpContext context)
    {
        using var scope = scopeFactory.CreateScope();
        var repositoryManager = scope.ServiceProvider.GetRequiredService<IRepositoryManager>();

        if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            var token = authHeader.ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userId = Guid.Parse(userIdClaim.Value);
                    var userAccessToken = await repositoryManager.User.GetUserAccessTokenById(userId);

                    if (userAccessToken is null || userAccessToken != token)
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "يرجى تسجيل الدخول."
                        }.ToString());

                        return;
                    }
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "يرجى تسجيل الدخول."
                    }.ToString());

                    return;
                }
            }
        }

        await next(context);
    }
}