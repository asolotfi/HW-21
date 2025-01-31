using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Contract.Sevice;
using HW_20.Infrastructure.DB;
using HW_20.Infrastructure.Repositoris;
using HW_20.Service.AppService;
using HW_20.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// پیکربندی سرویس‌های دیتابیس
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// خواندن apiKey از فایل تنظیمات
var apiKey = builder.Configuration["ApiKey"];


builder.Services.AddScoped<IAuthenticationService>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var apiKey = config.GetValue<string>("ApiSettings:ApiKey");

    var authRepository = provider.GetRequiredService<IAuthenticationRepository>();
    return new AuthenticationService(authRepository, apiKey);
});


// اضافه کردن سرویس‌ها
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInspectionRequestAppService, InspectionRequestAppService>();
builder.Services.AddScoped<IInspectionRequestService, InspectionRequestService>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();
builder.Services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
builder.Services.AddScoped<ICarModelSevice, CarModelSevice>();
builder.Services.AddScoped<ICarModelAppSevice, CarModelAppSevice>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();



// پیکربندی OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// تنظیمات مربوط به محیط توسعه و دیگر پیکربندی‌ها
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
