using Microsoft.AspNetCore.Diagnostics;

namespace Todo.Api
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is UnauthorizedAccessException)
            {
                await httpContext.Response.WriteAsJsonAsync("Unauthorized");
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                return true;
            }
            else
            {
                await httpContext.Response.WriteAsJsonAsync("Something went wrong");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return true;
            }




        }
    }
}
