using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Context;

namespace Paintball_Project.Infrastructure.Repositories;

public class GameDataRep : IGameDataRep
{
    private readonly PaintBallContext _context;
    private readonly DbSet<GameData> _gameData;

    public GameDataRep(PaintBallContext context)
    {
        _context = context;
        _gameData = _context.Set<GameData>();
    }

    public async Task<bool> CreateAsync(GameData gameData)
    {
        await _gameData.AddAsync(gameData);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<bool> DeleteAsync(GameData gameData)
    {
        _gameData.Remove(gameData);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<IEnumerable<GameDataResponse>> GetAsync()
    {
        var result = (from gameData in _gameData
                      .AsNoTracking()
                      select new GameDataResponse()
                      {
                          Id = gameData.Id,
                          NumberBalls = gameData.NumberBalls,
                          Price = gameData.Price,
                          Time = gameData.Time
                      }).AsEnumerable();

        return result;
    }

    public async Task<GameData> GetById(int id)
    {
        return await _gameData.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(GameData gameData)
    {
        _gameData.Update(gameData);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }
}
