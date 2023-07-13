using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Domain.Factories;

namespace Paintball_Project.Application.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRep _matchRep;
    public MatchService(IMatchRep matchRep)
    {
        _matchRep = matchRep;
    }

    //public async Task<bool> CreateAsync(MatchInsertRequest match)
    //{
    //    var gameDatas = await PrepareGameData(match.GameDatas);
    //    var chargeDatas = await PrepareChargeData(match.ChargeDatas);

    //    MatchSettings matchInsert = MatchSettingsFactory.Create
    //        (match.QuantityMaxPlayers,
    //         match.QuantityMinPlayers,
    //         match.DurationMatch,
    //         gameDatas,
    //         chargeDatas);

    //    return await _matchRep.CreateAsync(matchInsert);
    //}  

    public async Task<MatchResponse> GetAsync()
    {
        var matchResponse = await _matchRep.GetAsync();

        var matchSettings = await _matchRep.GetById(matchResponse.Id);
        var duration = matchSettings.DurationMatch;

        for (int i = 1; i <= duration; i++)
        {
           matchResponse.DurationMatch.Add(i);
        }

        return matchResponse;
    }

    public async Task<bool> UpdateAsync(MatchUpdateRequest match)
    {
        var matchUpdate = await _matchRep.GetById(match.Id);

        matchUpdate.Alterar
            (match.QuantityMaxPlayers,
            match.QuantityMinPlayers,
            match.DurationMatch);

        return await _matchRep.UpdateAsync(matchUpdate);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var matchDelete = await _matchRep.GetById(id);

        return await _matchRep.DeleteAsync(matchDelete);
    }

    #region aux
    //private async Task<ICollection<GameData>> PrepareGameData(ICollection<GameDataInsertRequest> gameData)
    //{
    //    var gameDatas = new List<GameData>();

    //    foreach (var item in gameData)
    //    {
    //        GameData result = GameDataFactory.Create(item.Price, item.NumberBalls, item.Time);
    //        gameDatas.Add(result);
    //    }

    //    return gameDatas;
    //}

    //private async Task<ICollection<ChargeData>> PrepareChargeData(ICollection<ChargeDataInsertRequest> chargeData)
    //{
    //    var gameDatas = new List<ChargeData>();

    //    foreach(var item in chargeData)
    //    {
    //        ChargeData result = ChargeDataFactory.Create(item.Price, item.NumberBalls);
    //        gameDatas.Add(result);
    //    }

    //    return gameDatas;
    //}
    #endregion
}
