using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;

namespace Paintball_Project.Application.Interfaces.Services;

public interface ISchedulingSettingsService
{
    Task<SchedulingSettingsResponse> GetAsync();
    Task<SchedulingSettingsResponse> UpdateAsync(SchedulingSettingsRequest request);
}
