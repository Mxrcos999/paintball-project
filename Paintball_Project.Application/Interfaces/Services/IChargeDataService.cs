using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.DTOs.Update;

namespace Paintball_Project.Application.Interfaces.Services;

public interface IChargeDataService
{
    Task<bool> CreateAsync(ChargeDataInsertRequest chargeData);
    Task<IEnumerable<ChargeDataResponse>> GetAsync();
    Task<bool> UpdateAsync(ChargeDataUpdateRequest chargeData);
    Task<bool> DeleteAsync(int id);
}

