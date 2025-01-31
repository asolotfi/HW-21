namespace HW_21_API.Middelware
{

    //public static class ApiKeyMiddlewareExtentions
    //{

    //}
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(HttpContext context)
        {

            _next(context);
        }
    }
    //public class ApiKeyMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly string _apiKey;

    //    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    //    {
    //        _next = next;
    //        _apiKey = configuration["ApiKey"]; // خواندن API Key از فایل تنظیمات
    //    }

    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey) || extractedApiKey != _apiKey)
    //        {
    //            // ثبت مقادیر برای عیب‌یابی
    //            Console.WriteLine($"Extracted: {extractedApiKey}, Expected: {_apiKey}");

    //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            await context.Response.WriteAsync("Unauthorized: Invalid API Key");
    //            return;
    //        }

    //        await _next(context);
    //    }
    //}
}
//public class ApiKeyMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly SiteSettings _siteSettings;
//    private static readonly List<string> WhitelistedActions = new()
//            {
//                "/admin",
//            };

//    public ApiKeyMiddleware(RequestDelegate next, SiteSettings siteSettings)
//    {
//        _next = next;
//        _siteSettings = siteSettings;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        var path = context.Request.Path.ToString();

//        if (WhitelistedActions.Any(x => path.ToUpper().Contains(x.ToUpper())) && path.ToUpper() != "/admin/AccessDenied".ToUpper())
//        {
//            if (context.Request.Cookies.TryGetValue("ApiKey", out var apiKey) && !string.IsNullOrEmpty(apiKey))
//            {
//                if (apiKey == _siteSettings.ApiKey)
//                {
//                    await _next(context);
//                }
//                else
//                {
//                    context.Response.Redirect("AccessDenied");
//                }
//            }
//            else
//            {
//                context.Response.Redirect("AccessDenied");
//            }
//        }
//        await _next(context);
//    }

