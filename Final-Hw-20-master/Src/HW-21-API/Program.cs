using FluentAssertions.Common;
using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using HW_20.Domain.Contract.Sevice;
using HW_20.Infrastructure.DB;
using HW_20.Infrastructure.Repositoris;
using HW_20.Service.AppService;
using HW_20.Service.Service;
using HW_21_API.Middelware;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// ثبت ApiKeyActionFilter در DI container
builder.Services.AddScoped<ApiKeyActionFilter>();

// اضافه کردن کنترلرها به DI container
builder.Services.AddControllers();

// پیکربندی سرویس‌های دیتابیس
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// خواندن apiKey از فایل تنظیمات
var apiKey = builder.Configuration["ApiKey"];

builder.Services.AddScoped<ApiKeyMiddleware>(); // اضافه کردن میدلور به DI

// اضافه کردن سرویس‌ها
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>(); // اطمینان حاصل کنید که پیاده‌سازی صحیحی ارائه شده است.
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
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
