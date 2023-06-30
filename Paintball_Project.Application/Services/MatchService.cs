using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Factories;

namespace Paintball_Project.Application.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRep _matchRep;
    public MatchService(IMatchRep matchRep)
    {
        _matchRep = matchRep;
    }

    public async Task<bool> CreateAsync(MatchInsertRequest match)
    {
        var matchInsert = MatchFactory.Create(match.Time, match.NumberBalls, match.Price);

        return await _matchRep.CreateAsync(matchInsert);
    }  
    
    public async Task<IEnumerable<MatchResponse>> GetAsync()
    {
         return await _matchRep.GetAsync();
    }

    public async Task<bool> UpdateAsync(MatchUpdateRequest match)
    {
        var matchUpdate = await _matchRep.GetById(match.Id);

        matchUpdate.Alterar(match.Time, match.NumberBalls, match.Price);

        return await _matchRep.UpdateAsync(matchUpdate);
    }   
    
    public async Task<bool> DeleteAsync(int id)
    {
        var matchDelete = await _matchRep.GetById(id);

        return await _matchRep.DeleteAsync(matchDelete);
    }
}
