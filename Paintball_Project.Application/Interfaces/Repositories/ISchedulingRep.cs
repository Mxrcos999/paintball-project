using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface ISchedulingRep
{
    Task<bool> InsertAsync(Scheduling request);
    Task<IEnumerable<SchedulingDay>> GetAvailableDaysAsync(int mouth, int day);
    Task<int> UpdateAsync(Player request);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<Scheduling>> GetAsync();
} 

