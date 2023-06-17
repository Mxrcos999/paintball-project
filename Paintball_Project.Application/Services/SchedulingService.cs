using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Domain.Factories;

namespace Paintball_Project.Application.Services;

public class SchedulingService : ISchedulingService
{
    private readonly ISchedulingRep _schedulingRep;
    public SchedulingService(ISchedulingRep schedulingRep)
    {
        _schedulingRep = schedulingRep;
    }
    public async Task<int> InsertAsync(SchedulingInsertRequest request)
    {
        var newPlayer = await CreatePlayerAsync(request.Player);

        var scheduling = SchedulingFactory.Create(newPlayer, request.NumberPlayer, request.DateHourScheduling);
        var idEntity = await _schedulingRep.InsertAsync(scheduling);
        return idEntity;
    }

    public Task<int> UpdateAsync(SchedulingInsertRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SchedulingDay>> GetAsync()
    {
        return await _schedulingRep.GetAvailableDaysAsync();
    }
    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    #region Auxiliary methods
    private async Task<Player> CreatePlayerAsync(PlayerInsertRequest playerDto)
    {
        var player = PlayerFactory.Create(playerDto.Name, playerDto.Phone);

        return player;
    }
    #endregion
}
