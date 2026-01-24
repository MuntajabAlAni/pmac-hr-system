using Domain.ErrorModel;

namespace API.Extensions;

public class ExpiredOrMissedTokenMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value != null)
        {
            var path = context.Request.Path.Value.ToLower();
            if (!path.Contains("login") &&
               !path.Contains("refresh") &&
               !path.Contains("register") &&
               !path.Contains("forgot-password") &&
               (context.Request.Method != "GET" ||
               (!path.EndsWith("ads") &&
               !path.Contains("products") &&
               !path.EndsWith("providers") &&
               !path.EndsWith("providers/all") &&
               !path.EndsWith("product-types"))) &&
               !path.Contains("chathub"))
            {
                if (context.User.Identity is null || !context.User.Identity.IsAuthenticated)
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