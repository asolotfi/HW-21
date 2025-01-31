using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Sevice;
using HW_20.Domain.Models;
using HW_20.Infrastructure.Repositoris;
using HW_20.Service.AppService;
using FluentValidation.AspNetCore;
using HW_20.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using HW_20.Service.Service;
using HW_20.Domain.Contract.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// بارگذاری تنظیمات از فایل پیکربندی
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// بارگذاری تنظیمات از appsettings.json
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// ثبت Validator
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InspectionRequestValidator>());


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInspectionRequestAppService, InspectionRequestAppService>();
builder.Services.AddScoped<IInspectionRequestService, InspectionRequestService>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();
builder.Services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<ICarModelSevice, CarModelSevice>();
builder.Services.AddScoped<ICarModelAppSevice, CarModelAppSevice>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
