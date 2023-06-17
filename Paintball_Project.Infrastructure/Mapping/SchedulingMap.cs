using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Infrastructure.Mapping;

public class SchedulingMap : IEntityTypeConfiguration<Scheduling>
{
    public void Configure(EntityTypeBuilder<Scheduling> builder)
    {
        builder.HasOne(x => x.Player)
            .WithOne()
            .HasConstraintName("fk_scheduling_player")
            .HasForeignKey<Scheduling>(x => x.PlayerId);

    }
}
