using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Factories;

namespace Paintball_Project.Application.Services;

public class ChargeDataService : IChargeDataService
{
    private readonly IChargeDataRep _chargeDataRep;
    private readonly IMatchRep _matchRep;

    public ChargeDataService(IChargeDataRep chargeDataRep, IMatchRep matchRep)
    {
        _chargeDataRep = chargeDataRep;
        _matchRep = matchRep;
    }

    public async Task<bool> CreateAsync(ChargeDataInsertRequest chargeData)
    {
        var matchId = (await _matchRep.GetAsync()).Id;
        var match = (await _matchRep.GetById(matchId));
      
        var newChargeData = ChargeDataFactory.Create(chargeData.Price, chargeData.NumberBalls, match);

        return await _chargeDataRep.CreateAsync(newChargeData);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var chargeData = await _chargeDataRep.GetById(id);

        return await _chargeDataRep.DeleteAsync(chargeData);
    }

    public async Task<IEnumerable<ChargeDataResponse>> GetAsync()
    {
        return await _chargeDataRep.GetAsync();
    }

    public async Task<bool> UpdateAsync(ChargeDataUpdateRequest chargeData)
    {
        var chargeDataFinded = await _chargeDataRep.GetById(chargeData.Id);
        chargeDataFinded.Alterar(chargeData.Price, chargeData.NumberBalls);

        return await _chargeDataRep.UpdateAsync(chargeDataFinded);
    }
}
