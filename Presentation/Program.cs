using Bussiness.Manager;
using Bussiness.Services;
using DAL.DbConnection;
using Data.DAL;
using Data.Repo;
using Entity.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using Validation.AppUserVal;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IOrdersService, OrderManager>();
builder.Services.AddScoped<IOrderDAL, OrderRepository>();

builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDAL, SocialMediaRepository>();

builder.Services.AddScoped<ICategoryService, CategoriesManager>();
builder.Services.AddScoped<ICategoryDAL, CategoryRepository>();

builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IContactUsDAL, ContactUsRepository>();

builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogDAL, BLogsRepository>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDAL, SocialMediaRepository>();

builder.Services.AddScoped<IAboutUsService, AboutUsManager>();
builder.Services.AddScoped<IAboutUsDAL,AboutUsRepository>();

builder.Services.AddScoped<IVideoService, VideosManager>();
builder.Services.AddScoped<IVideoDAL, VideoRepository>();

builder.Services.AddScoped<IFrequentlyQuestionService, FrequentlyQuestionsManager>();
builder.Services.AddScoped<IFrequentlyQuestionDAL, FrequentlyQuestionRepository>();

builder.Services.AddScoped<ISliderService, SLiderManager>();
builder.Services.AddScoped<ISliderDAL, SliderRepository>();

builder.Services.AddScoped<IEmailService, EmailManager>();

builder.Services.AddScoped<IBasketDAL, BasketRepository>();
builder.Services.AddScoped<IBasketService,BasketManager>();



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
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength =8;
    options.Password.RequireLowercase = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuöğıəşçvwxyzABCDEFGHIJŞÖĞIƏKLMNOPÇQRSTUVWXYZ0123456789";


}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
