using App.Domain.AppService;
using App.Domain.Core;
using App.Domain.Core._1_BaseEntities.AccountAppService;
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
using Framework;
using GetService.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//AccountAppService
builder.Services.AddScoped<IAccountAppService, AccountAppService>();

//Admin Services
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

//Bid
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBidAppService, BidAppService>();

//Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

//Comment
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();


//Customer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

//Expert
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();

//Request
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestService, RequestService>();

//Home Services
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServicesAppService, ServicesAppService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
#endregion

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


//Identity Configurations
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    }).AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "Areas",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
