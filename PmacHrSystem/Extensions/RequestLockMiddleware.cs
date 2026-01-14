using System.Collections.Concurrent;

namespace PmacHrSystem.Extensions;

public class RequestLockMiddleware(RequestDelegate next)
{
    private static readonly ConcurrentDictionary<string, SemaphoreSlim> Locks = new();

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.ToString().ToLower();
        if (path.Contains("chathub"))
        {
            await next(context);
            return;
        }

        var key = GetRequestKey(context);

        var semaphore = Locks.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

        var acquired = await semaphore.WaitAsync(0);

        if (!acquired)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            await context.Response.WriteAsync("Duplicate request in progress.");
            return;
        }

        try
        {
            await next(context);
        }
        finally
        {
            semaphore.Release();
        }
    }

    private static string GetRequestKey(HttpContext context)
    {
        var path = context.Request.Path.ToString().ToLower();
        var user = context.User.Identity?.Name ?? context.Connection.RemoteIpAddress?.ToString();

        return $"{user}:{path}";
    }
}