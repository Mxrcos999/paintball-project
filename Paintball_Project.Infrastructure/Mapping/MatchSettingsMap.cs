using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Infrastructure.Mapping;

public class MatchSettingsMap : IEntityTypeConfiguration<MatchSettings>
{
    public void Configure(EntityTypeBuilder<MatchSettings> builder)
    {
        builder
            .HasMany(x => x.GameDatas)
            .WithOne(x => x.MatchSettings)
            .HasForeignKey(x => x.MatchSettingsId);     
        
        builder
            .HasMany(x => x.ChargeDatas)
            .WithOne(x => x.MatchSettings)
            .HasForeignKey(x => x.MatchSettingsId);
    }
}
