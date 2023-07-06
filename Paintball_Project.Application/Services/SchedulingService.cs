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
    public async Task<DefaultResponse> InsertAsync(SchedulingInsertRequest request)
    {
        var response = new DefaultResponse();

        var schedulings = (await _schedulingRep.GetAsync()).Where(wh => wh.DateHourScheduling == request.DateHourScheduling);
        if(schedulings.Count() < 3)
        {
            var totalPlayers = schedulings?.Sum(s => s.NumberPlayer);
            var totalPlayersScheduling = totalPlayers + request.NumberPlayer;

            if (totalPlayersScheduling <= 40)
            {
                var newPlayer = await CreatePlayerAsync(request.Player);

                var scheduling = SchedulingFactory.Create(newPlayer, request.NumberPlayer, request.DateHourScheduling, request.DurationMatch);
                var result = await _schedulingRep.InsertAsync(scheduling);

                response.Sucess = result;
                return response;
            }
            response.Sucess = false;
            response.AddError("O horario selecionado já atingiu o número máximo de jogadores.");
            return response;

        }
        response.Sucess = false;
        response.AddError("O horario selecionado já contém 3 jogos agendados.");
        return response;
    }

    public Task<int> UpdateAsync(SchedulingInsertRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SchedulingDay>> GetAsync(int mounth, int day)
    {
        return await _schedulingRep.GetAvailableDaysAsync(mounth, day);
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
