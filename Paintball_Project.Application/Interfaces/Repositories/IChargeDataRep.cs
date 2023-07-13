using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.Interfaces.Repositories;

public interface IChargeDataRep
{
    Task<bool> CreateAsync(ChargeData chargeData);
    Task<IEnumerable<ChargeDataResponse>> GetAsync();
    Task<bool> UpdateAsync(ChargeData chargeData);
    Task<bool> DeleteAsync(ChargeData chargeData);
    Task<ChargeData> GetById(int id);
}
