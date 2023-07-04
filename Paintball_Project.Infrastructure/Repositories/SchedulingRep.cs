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
    private readonly DbSet<SchedulingSettings> _schedulingSettings;
    private readonly int numberPlayer;
    private readonly int durationMatch;

    public SchedulingRep(PaintBallContext context)
    {
        _context = context;
        _scheduling = context.Set<Scheduling>();
        _schedulingSettings = context.Set<SchedulingSettings>();
        numberPlayer = _schedulingSettings.FirstOrDefault().NumberPlayer;
        durationMatch = _schedulingSettings.FirstOrDefault().DurationMatch;
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Scheduling>> GetAsync()
    {
        return _scheduling.AsEnumerable();
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
                var endHourSlot = beginHour.AddHours(durationMatch);

                var totalPlayersHour = schedulings.Where(a => a.DateHourScheduling >= beginHour && a.DateHourScheduling < beginHour.AddHours(durationMatch));
                var totalPlayers = totalPlayersHour.Sum(a => a.NumberPlayer);

                if (totalPlayersHour.Count() < 3 && totalPlayers < numberPlayer)
                {
                    availableHours.Add(beginHour.ToString("HH:mm"));
                }
                beginHour = beginHour.AddHours(durationMatch);

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

    public Task<int> UpdateAsync(Player request)
    {
        throw new NotImplementedException();
    }
}
