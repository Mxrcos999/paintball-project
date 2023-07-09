using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface ISchedulingRep
{
    Task<bool> InsertAsync(Scheduling request);
    Task<IEnumerable<SchedulingDay>> GetAvailableDaysAsync(int mouth, int day);
    Task<bool> UpdateAsync(Scheduling request);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<SchedulingResponse>> GetAsync();
    Task<Scheduling> GetById(int id);
}

