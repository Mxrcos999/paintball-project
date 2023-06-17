using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Application.Services;
using Paintball_Project.Infrastructure.Context;
using Paintball_Project.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PaintBallContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("strConnection")));
builder.Services.AddScoped<ISchedulingRep, SchedulingRep>();
builder.Services.AddScoped<ISchedulingService, SchedulingService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
