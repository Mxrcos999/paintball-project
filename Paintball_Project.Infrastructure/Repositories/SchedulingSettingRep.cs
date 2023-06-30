using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Context;

namespace Paintball_Project.Infrastructure.Repositories;

public class SchedulingSettingRep : ISchedulingSettingsRep
{
    private readonly PaintBallContext _context;
    private readonly DbSet<SchedulingSettings> _schedulingSettings;

    public SchedulingSettingRep(PaintBallContext context)
    {
        _context = context;
        _schedulingSettings = context.Set<SchedulingSettings>();
    }
    public async Task<SchedulingSettingsResponse> UpdateAsync(SchedulingSettings request)
    {
        _schedulingSettings.Update(request);

        await _context.SaveChangesAsync();

        return new SchedulingSettingsResponse()
        {
            DurationMatch = request.DurationMatch,
            NumberPlayer = request.NumberPlayer
        };
    }

    public async Task<SchedulingSettingsResponse> GetAsync()
    {
        var schedulingSetting = await (from scheduling in _schedulingSettings
                                .AsNoTracking()
                                       select new SchedulingSettingsResponse()
                                       {
                                           Id = scheduling.Id,
                                           DurationMatch = scheduling.DurationMatch,
                                           NumberPlayer = scheduling.NumberPlayer
                                       }).SingleOrDefaultAsync();
        if (schedulingSetting is null)
            return null;

        return schedulingSetting;
    }

    public async Task<SchedulingSettings> GetByIdAsync(int id)
    {
        var scheduling = await _schedulingSettings.FindAsync(id);

        return scheduling;
    }
}
