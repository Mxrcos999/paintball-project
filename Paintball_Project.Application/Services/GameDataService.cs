using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Factories;

namespace Paintball_Project.Application.Services;

public class GameDataService : IGameDataService
{
    private readonly IGameDataRep _gameDataRep;
    private readonly IMatchRep _matchRep;

    public GameDataService(IGameDataRep gameDataRep, IMatchRep matchRep)
    {
        _gameDataRep = gameDataRep;
        _matchRep = matchRep;
    }

    public async Task<bool> CreateAsync(GameDataInsertRequest gameData)
    {
        var matchId = (await _matchRep.GetAsync()).Id;
        var match = (await _matchRep.GetById(matchId));

        var game = GameDataFactory.Create
            (gameData.Price, 
            gameData.NumberBalls,
            gameData.NumberBalls,
            match);

        return await _gameDataRep.CreateAsync(game);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var game = await _gameDataRep.GetById(id);

        return await _gameDataRep.DeleteAsync(game);
    }

    public async Task<IEnumerable<GameDataResponse>> GetAsync()
    {
        return await _gameDataRep.GetAsync();
    }

    public async Task<bool> UpdateAsync(GameDataUpdateRequest gameData)
    {
        var game = await _gameDataRep.GetById(gameData.Id);
        game.Alterar(gameData.Price, gameData.NumberBalls, gameData.Time);

        return await _gameDataRep.UpdateAsync(game);
    }
}
