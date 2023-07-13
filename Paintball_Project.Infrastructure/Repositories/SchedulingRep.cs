using Microsoft.EntityFrameworkCore;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Repositories;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Infrastructure.Context;
using System.Globalization;

namespace Paintball_Project.Infrastructure.Repositories;

public class SchedulingRep : ISchedulingRep
{
    private readonly PaintBallContext _context;
    private readonly DbSet<Scheduling> _scheduling;
    private readonly DbSet<MatchSettings> _matchSettings;
    private readonly int numberPlayer;

    public SchedulingRep(PaintBallContext context)
    {
        _context = context;
        _scheduling = context.Set<Scheduling>();
        _matchSettings = context.Set<MatchSettings>();
        numberPlayer = _matchSettings.FirstOrDefault().QuantityMaxPlayers;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var scheduling = await _scheduling.FindAsync(id);

        _scheduling.Remove(scheduling);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }
    public async Task<IEnumerable<SchedulingResponse>> GetAsync()
    {
        var result = (from scheduling in _scheduling
                      .AsNoTracking()
                      select new SchedulingResponse()
                      {
                          Id = scheduling.Id,
                          DateTimeRegistration = scheduling.DateTimeCreating,
                          DateTimeScheduling = scheduling.DateHourScheduling,
                          DurationMatch = scheduling.DurationMatch,
                          NumberPlayers = scheduling.NumberPlayer,
                          Phone = scheduling.Phone,
                          PlayerName = scheduling.Name
                      }).AsEnumerable();

        return result;
    }
    public async Task<IEnumerable<SchedulingDay>> GetAvailableDaysAsync(int mouth, int day)
    {
        var schedulings = _scheduling.AsEnumerable();

        var currentYear = DateTime.Now.Year;

        var firstDayMonth = new DateTime(currentYear, mouth, 1);
        var lastDayMonth = firstDayMonth.AddMonths(1).AddDays(-1);

        var daysTimesAvailable = new List<SchedulingDay>();

        if (day >= firstDayMonth.Day && day <= lastDayMonth.Day)
        {
            var selectedDate = new DateTime(currentYear, mouth, day);

            var beginHour = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 8, 0, 0);
            var endHour = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 21, 0, 0);

            var availableHours = new List<string>();

            while (beginHour < endHour)
            {
                var endHourSlot = beginHour.AddHours(1);

                var totalPlayersHour = schedulings.Where(a => a.DateHourScheduling >= beginHour && a.DateHourScheduling < beginHour.AddHours(1));
                var totalPlayers = totalPlayersHour.Sum(a => a.NumberPlayer);

                if (totalPlayersHour.Count() < 3 && totalPlayers < numberPlayer)
                {
                    availableHours.Add(beginHour.ToString("HH:mm"));
                }
                else
                {
                    endHourSlot = beginHour.AddHours(totalPlayersHour.Max(x => x.DurationMatch));
                }

                beginHour = endHourSlot;
            }

            daysTimesAvailable.Add(new SchedulingDay
            {
                Mouth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mouth),
                Year = selectedDate.Year,
                Day = selectedDate.Day,
                HoursAvailable = availableHours
            });
        }

        return daysTimesAvailable;
    }
    public async Task<bool> InsertAsync(Scheduling request)
    {
        try
        {
            await _scheduling.AddAsync(request);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;

            return false;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<bool> UpdateAsync(Scheduling scheduling)
    {
        _scheduling.Update(scheduling);

        var result = await _context.SaveChangesAsync();

        if (result > 0)
            return true;

        return false;
    }
    public async Task<Scheduling> GetById (int id)
    {
        return await _scheduling.FindAsync(id);
    }
}
