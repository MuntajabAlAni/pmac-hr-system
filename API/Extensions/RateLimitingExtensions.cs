using System.Threading.RateLimiting;

namespace API.Extensions;

public static class RateLimitingExtensions
{
    public static RateLimitPartition<string> GetRemoteIpAddressLimiter(HttpContext context,
        Func<string, RateLimitPartition<string>> factory)
    {
        var ipAddress = context.Connection.RemoteIpAddress;

        var ipString = ipAddress?.ToString() ?? "unknown";

        return factory(ipString);
    }
}