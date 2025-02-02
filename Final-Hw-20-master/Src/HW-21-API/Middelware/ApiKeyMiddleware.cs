using HW_20.Domain.Entites.Configs;

public class ApiKeyMiddleware
{
    //private readonly RequestDelegate _next;
    //private readonly string _apiKey;

    //public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    //{
    //    _next = next;
    //    _apiKey = configuration["ApiKey"];
    //}

    //public async Task InvokeAsync(HttpContext context)
    //{
    //    if (!context.Request.Headers.TryGetValue("ApiKey", out var receivedApiKey) ||
    //        receivedApiKey != _apiKey)
    //    {
    //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //        await context.Response.WriteAsync("Unauthorized");
    //        return;
    //    }

    //    await _next(context);
    //}
}



