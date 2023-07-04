using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;

namespace Paintball_Project.Application.Interfaces.Services;

public interface ISchedulingService
{
    Task<DefaultResponse> InsertAsync(SchedulingInsertRequest request);
    Task<IEnumerable<SchedulingDay>> GetAsync(int mounth, int day);
    Task<int> UpdateAsync(SchedulingInsertRequest request);
    Task<int> DeleteAsync(int id);
} 
