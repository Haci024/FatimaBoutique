using Bussiness.Manager;
using Bussiness.Services;
using DAL.DbConnection;
using Data.DAL;
using Data.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
