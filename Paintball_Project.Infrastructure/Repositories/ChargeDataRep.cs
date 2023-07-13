using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Context;

namespace Paintball_Project.Infrastructure.Repositories;

public class ChargeDataRep : IChargeDataRep
{
    private readonly PaintBallContext _context;
    private readonly DbSet<ChargeData> _chargeData;

    public ChargeDataRep(PaintBallContext context)
    {
        _context = context;
        _chargeData = _context.Set<ChargeData>();
    }

    public async Task<bool> CreateAsync(ChargeData chargeData)
    {
        await _chargeData.AddAsync(chargeData);

        var result = await _context.SaveChangesAsync();
       
        if (result > 0)
            return true;

        return false;
    }

    public async Task<bool> DeleteAsync(ChargeData chargeData)
    {
        _chargeData.Remove(chargeData);
        
        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<IEnumerable<ChargeDataResponse>> GetAsync()
    {
        var data = (from charge in _chargeData
                    .AsNoTracking()
                    select new ChargeDataResponse()
                    {
                        Id = charge.Id,
                        NumberBalls = charge.NumberBalls,
                        Price = charge.Price
                    }).AsEnumerable();

        return data;
    }

    public async Task<ChargeData> GetById(int id)
    {
        return await _chargeData.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(ChargeData chargeData)
    {
        _chargeData.Update(chargeData);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }
}
