using System.Net;
using System.Text;

namespace API.Extensions;

public class SwaggerAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value != null && context.Request.Path.Value.Contains("/swagger"))
        {
            string? authHeader = context.Request.Headers.Authorization;
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                {
                    var decodedUsernamePassword =
                        Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    if (IsAuthorized(username, password, configuration))
                    {
                        await next.Invoke(context);
                        return;
                    }
                }
            }

            context.Response.Headers.WWWAuthenticate = "Basic";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context);
        }
    }

    public static bool IsAuthorized(string username, string password, IConfiguration configuration)
    {
        var configUsername = configuration.GetValue<string>("SwaggerAuthentication:Username");
        var configPassword = configuration.GetValue<string>("SwaggerAuthentication:Password");

        if (string.IsNullOrWhiteSpace(configUsername) && string.IsNullOrWhiteSpace(configPassword))
            return true;

        return username.Equals(configUsername, StringComparison.InvariantCultureIgnoreCase)
               && password.Equals(configPassword);
    }
}