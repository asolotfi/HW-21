using HW_20.Domain.Entites.Configs;
using HW_20.Domain.Models;

namespace HW_21_API.Middelware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _apiKey = configuration["ApiKey"]; // خواندن API Key از فایل تنظیمات
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey) || extractedApiKey != _apiKey)
            {
                context.Response.StatusCode = 401; // اطمینان از تنظیم شدن وضعیت پاسخ به 401
                await context.Response.WriteAsync("Unauthorized: Invalid API Key");
                return;
            }

            await _next(context);
        }

    }
}


