using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface IGameDataRep 
{
    Task<bool> CreateAsync(GameData gameData);
    Task<IEnumerable<GameDataResponse>> GetAsync();
    Task<bool> UpdateAsync(GameData gameData);
    Task<bool> DeleteAsync(GameData gameData);
    Task<GameData> GetById(int id);
}
