using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface ISchedulingRep
{
    Task<int> InsertAsync(Scheduling request);
    Task<IEnumerable<SchedulingDay>> GetAvailableDaysAsync();
    Task<int> UpdateAsync(Player request);
    Task<int> DeleteAsync(int id);
} 

