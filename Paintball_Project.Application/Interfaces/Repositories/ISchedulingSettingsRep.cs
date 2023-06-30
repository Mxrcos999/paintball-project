using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface ISchedulingSettingsRep
{
    Task<SchedulingSettingsResponse> GetAsync();
    Task<SchedulingSettings> GetByIdAsync(int id);
    Task<SchedulingSettingsResponse> UpdateAsync(SchedulingSettings request);
}
