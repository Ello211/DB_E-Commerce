using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using DB_ECommerce.Application; // Falls dein Application-Projekt diesen Namespace hat
using DB_ECommerce.Persistence;
using DB_ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DB_ECommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MongoDB settings from appsettings.json
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Inject MongoDbSettings into DB_ECommerceContext
builder.Services.AddScoped<DB_ECommerceContext>();

// Register MongoDB Repository
builder.Services.AddScoped<ReviewRepository>();

// **MediatR für die gesamte Application-Assembly registrieren**
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DB_ECommerce.Application.AssemblyReference).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();