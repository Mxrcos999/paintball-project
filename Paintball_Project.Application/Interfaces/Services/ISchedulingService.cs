using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;

namespace Paintball_Project.Application.Interfaces.Services;

public interface ISchedulingService
{
    Task<DefaultResponse> InsertAsync(SchedulingInsertRequest request);
    Task<IEnumerable<SchedulingDay>> GetAsync(int mounth, int day);
    Task<bool> UpdateAsync(SchedulingUpdateRequest request);
    Task<bool> DeleteAsync(int id);
} 
