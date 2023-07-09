using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface IMatchRep
{
    Task<bool> CreateAsync(MatchSettings match);
    Task<IEnumerable<MatchResponse>> GetAsync();
    Task<bool> UpdateAsync(MatchSettings match);
    Task<bool> DeleteAsync(MatchSettings match);
    Task<MatchSettings> GetById(int id);
}
