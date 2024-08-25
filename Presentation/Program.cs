using Business.Manager;
using Business.Services;
using Bussiness.Manager;
using Bussiness.Services;
using DAL.DbConnection;
using Data.DAL;
using Data.Repo;
using Entity.Models;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Presentation.Helper;
using System;
using System.Globalization;
using Validation.AppUserVal;
using LanguageManager = Presentation.Helper.LanguageManager;





var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<LanguageManager>();
builder.Services.AddScoped<ILanguagesService, LanguagesManager>();
builder.Services.AddScoped<ILanguageDAL, LanguageRepository>();

builder.Services.AddScoped<LayoutService>();

builder.Services.AddScoped<IOrdersService, OrderManager>();
builder.Services.AddScoped<IOrderDAL, OrderRepository>();



builder.Services.AddScoped<ICategoryService, CategoriesManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryRepository>();

builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDAL, ContactUsRepository>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDAL, ProductsRepository>();


builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<IGoogleCloudStorageService, GoogleCloudStorageManager>();

builder.Services.AddScoped<IVideoService, VideosManager>();
builder.Services.AddScoped<IVideoDAL, VideoRepository>();

builder.Services.AddScoped<IFrequentlyQuestionService, FrequentlyQuestionsManager>();
builder.Services.AddScoped<IFrequentlyQuestionDAL, FrequentlyQuestionRepository>();




builder.Services.AddScoped<ISliderService, SLiderManager>();
builder.Services.AddScoped<ISliderDAL, SliderRepository>();

builder.Services.AddScoped<IEmailService, EmailManager>();

builder.Services.AddScoped<IBasketDAL, BasketRepository>();
builder.Services.AddScoped<IBasketService,BasketManager>();

builder.Services.AddScoped<IProductImagesDAL,ProductImagesRepository>();
builder.Services.AddScoped<IProductImageService, ProductImagesManager>();




builder.Services.AddScoped<ISubscriberDAL, SubscriberRepository>();
builder.Services.AddScoped<ISubscriberService, SubscriberManager>();




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Home/Error";
});


builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
})
   

  

.AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>()
.AddDefaultTokenProviders();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("tr-TR"), new CultureInfo("ru-RU"), new CultureInfo("az-AZ") };
    options.DefaultRequestCulture = new RequestCulture("az-AZ");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
