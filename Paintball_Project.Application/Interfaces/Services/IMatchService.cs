using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;

namespace Paintball_Project.Application.Interfaces.Services;

public interface IMatchService
{
    Task<bool> CreateAsync(MatchInsertRequest match);
    Task<IEnumerable<MatchResponse>> GetAsync();
    Task<bool> UpdateAsync(MatchUpdateRequest match);
    Task<bool> DeleteAsync(int id);
}
