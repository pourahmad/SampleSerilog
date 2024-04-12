using Serilog.Context;

namespace SampleSerilog.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;

        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("UserName", context.User.Identity?.Name);
            LogContext.PushProperty("UserIpAddress", context.Connection.RemoteIpAddress?.ToString());

            return next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogUserNameMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUserNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogUserNameMiddleware>();
        }
    }
}
