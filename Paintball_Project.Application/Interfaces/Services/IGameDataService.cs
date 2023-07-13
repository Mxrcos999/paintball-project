using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;

namespace Paintball_Project.Application.Interfaces.Services;

public interface IGameDataService
{
    Task<bool> CreateAsync(GameDataInsertRequest gameData);
    Task<IEnumerable<GameDataResponse>> GetAsync();
    Task<bool> UpdateAsync(GameDataUpdateRequest gameData);
    Task<bool> DeleteAsync(int id);
}
