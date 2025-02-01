using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HW_21_API.Middelware
{
    public class ApiKeyActionFilter : IActionFilter
    {
        private readonly string _apiKey;

        public ApiKeyActionFilter(IConfiguration configuration)
        {
            _apiKey = configuration["ApiKey"]; // خواندن API Key از فایل تنظیمات
        }

        //Middleware برای اعتبارسنجی API Key
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey) ||
                extractedApiKey != _apiKey)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

