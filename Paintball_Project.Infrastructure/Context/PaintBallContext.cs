using Microsoft.EntityFrameworkCore;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Infrastructure.Context;

public class PaintBallContext : DbContext
{
    public PaintBallContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Scheduling> schedulings { get; set; }
}
