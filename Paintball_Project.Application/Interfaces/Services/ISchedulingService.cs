using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;

namespace Paintball_Project.Application.Interfaces.Services;

public interface ISchedulingService
{
    Task<int> InsertAsync(SchedulingInsertRequest request);
    Task<IEnumerable<SchedulingDay>> GetAsync();
    Task<int> UpdateAsync(SchedulingInsertRequest request);
    Task<int> DeleteAsync(int id);
} 
