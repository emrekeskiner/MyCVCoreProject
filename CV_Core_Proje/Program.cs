using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using MyCVCore.BusinessLayer.Abstract;
using MyCVCore.BusinessLayer.Concrete;
using MyCVCore.DataAccessLayer.Abstract;
using MyCVCore.DataAccessLayer.Context;
using MyCVCore.DataAccessLayer.EntityFramework;
using MyCVCore.EntityLayer.Concrete;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CvContext>();
builder.Services.AddIdentity<WriterUser,WriterRole>().AddEntityFrameworkStores<CvContext>();
builder.Services.AddScoped<IAnnouncementService,AnnouncementManager>();
builder.Services.AddScoped<IAnnouncementDal,EfAnnouncementDal>();
builder.Services.AddScoped<IWriterMessageService,WriterMessageManager>();
builder.Services.AddScoped<IWriterMessageDal,EfWriterMessageDal>();
builder.Services.AddScoped<IMessageService,MessageManager>();
builder.Services.AddScoped<IMessageDal,EfMessageDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal,EfSocialMediaDal>();
builder.Services.AddScoped<IWriterUserService, WriterUserManager>();
builder.Services.AddScoped<IWriterUserDal, EfWriterUserDal>();
builder.Services.AddMvcCore(config=>
{
    var policy=new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.HttpOnly = true;
    config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    config.AccessDeniedPath = "/ErrorPage/Error";
    config.LoginPath = "/Writer/Login/UserLogin/";
});
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Writer/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Writer/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Writer",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");



app.Run();
