using Microsoft.AspNetCore.Builder;

namespace Infraestructure.Crosscutting.Logging
{
    public static class LoggingExtension
    {
        public static void AddCustomErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}