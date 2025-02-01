using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HW_21_API.Middelware
{
    public class ApiKeyActionFilter /*: IActionFilter*/
    {
        //private readonly RequestDelegate _next;
        //private readonly string _apiKey;
        //private string? apiKey;

        //public ApiKeyActionFilter(RequestDelegate next, IConfiguration configuration)
        //{
        //    _next = next;
        //    _apiKey = configuration["ApiKey"]; // خواندن API Key از فایل تنظیمات
        //}

        //public ApiKeyActionFilter(string? apiKey)
        //{
        //    this.apiKey = apiKey;
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey) ||
        //        extractedApiKey != _apiKey)
        //    {
        //        context.Result = new UnauthorizedResult();
        //    }
        //}

        //public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
