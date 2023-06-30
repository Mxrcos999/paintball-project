using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Mapping;

namespace Paintball_Project.Infrastructure.Context;

public class PaintBallContext : IdentityDbContext<ApplicationUser>
{
    public PaintBallContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Scheduling> scheduling { get; set; }
    public DbSet<Player> player { get; set; }
    public DbSet<ApplicationUser> user { get; set; }
    public DbSet<SchedulingSettings> schedulesettings { get; set; }
    public DbSet<Match> match { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SchedulingMap());
    }

}
