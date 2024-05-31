using App.Domain.AppService;
using App.Domain.Core;
using App.Domain.Core._1_BaseEntities.AccountAppService;
using App.Domain.Core.CategoryEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Service;
using App.Infra.DataAccess.Repo.EF;
using App.Infra.DB.SQLServer.EF;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Services
//category
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Requests
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();

//Account
builder.Services.AddScoped<IAccountAppService, AccountAppService>();

//MemoryCache
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

//DbContext
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GetService - Final;Integrated Security=True;TrustServerCertificate=True;"));

#endregion

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(Option =>
{
    Option.AllowAnyMethod();
    Option.AllowAnyHeader();
    Option.AllowAnyOrigin();
});

app.Run();
