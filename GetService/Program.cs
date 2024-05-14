using App.Domain.AppService;
using App.Domain.Core._2_Configs;
using App.Domain.Core.AdminEntity.Contracts;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Domain.Service;
using App.Infra.DataAccess.Repo.EF;
using App.Infra.DB.SQLServer.EF;
using GetService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();


//Admin Services
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

//Bid Services
builder.Services.AddScoped<IBidRepository, BidRepository>();

//Category Services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

//Comment Services
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();


//Customer Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//Expert Services
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();

//Request Services
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestService, RequestService>();

//Home Services
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServicesAppService, ServicesAppService>();
builder.Services.AddScoped<IServicesService, ServicesService>();


//Add appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Map SiteSetting Section in AppSettings.json to SiteSetting Class
var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);


//Add Sql Connection String
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(siteSettings.SqlConfigurations.ConnectionString)
    );


//Seq Configurations
builder.Services.AddLogging(LoggingBuilder =>
{
    LoggingBuilder.ClearProviders();
    LoggingBuilder.AddSeq(configuration.GetSection("SiteSettings:Seq"));
});


//Serilog Configurations
//builder.Host.ConfigureLogging(LoggingBuilder =>
//{
//    LoggingBuilder.ClearProviders();

//}).UseSerilog((context, config) =>
//{
//    config.WriteTo.Seq(siteSettings.SeqConfigurations.UrlAddress,
//        LogEventLevel.Warning,
//        apiKey: siteSettings.SeqConfigurations.ApiToken
//        );
//});


var app = builder.Build();


app.UseCustomException();


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
    name: "Areas",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
