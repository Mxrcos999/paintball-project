

using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Application.Services;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Identity.Services;
using Paintball_Project.Infrastructure.Context;
using Paintball_Project.Infrastructure.Repositories;
using Paintball_Project.Storage.Services;
using PaintBall_Project.Api.Extensions;

namespace PaintBall_Project.Api.Ioc;

public static class NativeInjectorConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PaintBallContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("strConnection")));
        services.AddScoped<ISchedulingService, SchedulingService>();
        services.AddScoped<ISchedulingRep, SchedulingRep>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IAzureStorageService, AzureStorageService>();
        services.AddScoped<IMatchService, MatchService>();
        services.AddScoped<IMatchRep, MatchRep>();
        services.AddScoped<IChargeDataRep, ChargeDataRep>();
        services.AddScoped<IChargeDataService, ChargeDataService>(); 
        services.AddScoped<IGameDataRep, GameDataRep>();
        services.AddScoped<IGameDataService, GameDataService>();

        string storageAccountName = "paintballstorage";
        string storageAccountKey = "rqKu/8zhwe7fZRUojXPB1Emi9byiA8WGMkjYWEG8NnWvGzFMlk/4CL1y2KBmuKOjCEh/6n08WxBi+ASt+AaUTA==";
        services.AddScoped<BlobServiceClient>(provider =>
        {
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey};EndpointSuffix=core.windows.net";
            return new BlobServiceClient(connectionString);
        });
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddRoles<IdentityRole>()
           .AddDefaultTokenProviders()
           .AddEntityFrameworkStores<PaintBallContext>()
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>()
           .AddDefaultTokenProviders();

        services.AddAuthentication(configuration);
        services.AddAuthorizationPolicies();
    }
}
