using RestaurantAPI.Exeptions;

namespace RestaurantAPI.Middleware
{
    public class ErrorHandingMiddleware: IMiddleware
    {   
        private readonly ILogger _logger;
        public ErrorHandingMiddleware(ILogger<ErrorHandingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);

                context.Response.StatusCode = 500;
               await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
