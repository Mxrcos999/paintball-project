using Microsoft.EntityFrameworkCore;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Mapping;

namespace Paintball_Project.Infrastructure.Context;

public class PaintBallContext : DbContext
{
    public PaintBallContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Scheduling> scheduling { get; set; }
    public DbSet<Player> player { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SchedulingMap());
    }

}
