using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;

namespace Paintball_Project.Application.Services;

public class SchedulingSettingsService : ISchedulingSettingsService
{
    private readonly ISchedulingSettingsRep _settingsRep;
    public SchedulingSettingsService(ISchedulingSettingsRep settingsRep)
    {
        _settingsRep = settingsRep;
    }

    public async Task<SchedulingSettingsResponse> UpdateAsync(SchedulingSettingsRequest request)
    {
        var setting = await _settingsRep.GetByIdAsync(request.Id);
        setting.Update(request.NumberPlayer, request.DurationMatch);

        await _settingsRep.UpdateAsync(setting);

        return await GetAsync();
    }

    public async Task<SchedulingSettingsResponse> GetAsync()
    {
        var settings = await _settingsRep.GetAsync();

        return settings;
    }
}
