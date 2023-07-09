﻿using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Context;

namespace Paintball_Project.Infrastructure.Repositories;

public class MatchRep : IMatchRep
{
    private readonly PaintBallContext _paintBallContext;
    private readonly DbSet<MatchSettings> _match;
    public MatchRep(PaintBallContext paintBallContext)
    {
        _paintBallContext = paintBallContext;
        _match = paintBallContext.Set<MatchSettings>();
    }
    public async Task<bool> CreateAsync(MatchSettings match)
    {
        await _match.AddAsync(match);

        var result = await _paintBallContext.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<bool> DeleteAsync(MatchSettings match)
    {
        _match.Remove(match);

        var result = await _paintBallContext.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<IEnumerable<MatchResponse>> GetAsync()
    {
        var matchResponse = (from match in _match
                            .AsNoTracking()
                            select new MatchResponse()
                            {
                                Id = match.Id,
                                QuantityMaxPlayers = match.QuantityMaxPlayers,
                                QuantityMinPlayers = match.QuantityMinPlayers,
                                DurationMatch = match.DurationMatch,
                            }).AsEnumerable();

        return matchResponse;
    }

    public async Task<bool> UpdateAsync(MatchSettings match)
    {
        _match.Update(match);

        var result = await _paintBallContext.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }

    public async Task<MatchSettings> GetById(int id)
    {
        var match = await _match.FindAsync(id);

        return match;

    }
}
