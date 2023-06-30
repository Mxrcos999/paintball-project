using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface IMatchRep
{
    Task<bool> CreateAsync(Match match);
    Task<IEnumerable<MatchResponse>> GetAsync();
    Task<bool> UpdateAsync(Match match);
    Task<bool> DeleteAsync(Match match);
    Task<Match> GetById(int id);
}
