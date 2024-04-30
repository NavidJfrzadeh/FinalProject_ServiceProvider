using App.Domain.Core.AdminEntity.Contracts;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.ServiceEntity.Contracts;
using App.Infra.DataAccess.Repo.EF;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Add appsettings.json
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Add Connection String
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(configuration.GetSection("ConnectionStrings:AppConnectionString").Value)
    );


//Admin Services
builder.Services.AddScoped<IAdminRepository, AdminRepository > ();

//Bid Services
builder.Services.AddScoped<IBidRepository, BidRepository> ();

//Category Services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository> ();

//Comment Services
builder.Services.AddScoped<ICommentRepository,  CommentRepository> ();

//Customer Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository > ();

//Expert Services
builder.Services.AddScoped<IExpertRepository, ExpertRepository > ();

//Request Services
builder.Services.AddScoped<IRequestRepository, RequestRepository> ();

//Home Services
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();


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
