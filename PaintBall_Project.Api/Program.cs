using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Application.Services;
using Paintball_Project.Infrastructure.Context;
using Paintball_Project.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PaintBallContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("strConnection")));
builder.Services.AddScoped<ISchedulingService, SchedulingService>();
builder.Services.AddScoped<ISchedulingRep, SchedulingRep>();
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

app.Run();
