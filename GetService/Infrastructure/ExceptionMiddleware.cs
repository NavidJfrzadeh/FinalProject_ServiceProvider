namespace GetService.Infrastructure;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex.Message);
            //await context.Response.WriteAsync(ex.Message);
            context.Response.Redirect("/Home/Error");
        }
    }
}

//create extension for use same as other middlewares
public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
