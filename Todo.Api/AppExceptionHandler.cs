using Microsoft.AspNetCore.Diagnostics;

namespace Todo.Api
{
    public class AppExceptionHandler: IExceptionHandler
    {
        private readonly ILogger _logger;
        public AppExceptionHandler(ILogger<AppExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Unhandlesd exception occured: {Message}", exception.Message);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync("Something went wrong.", cancellationToken);

            return true;

        }
    }
}
