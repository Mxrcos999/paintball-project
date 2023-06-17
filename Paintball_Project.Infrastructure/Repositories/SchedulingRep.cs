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
    public SchedulingRep(PaintBallContext context)
    {
        _context = context;
        _scheduling = context.Set<Scheduling>();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SchedulingDay>> GetAvailableDaysAsync()
    {
        var schedulings = _scheduling.AsEnumerable();
        var currentYear = DateTime.Now.Year;
        var monthsAppointments = new List<SchedulingDay>();

        for (var month = 1; month <= 12; month++)
        {
            var firstDayMonth = new DateTime(currentYear, month, 1);
            var lastDayMonth = firstDayMonth.AddMonths(1).AddDays(-1);

            var daysTimesAvailable = new List<SchedulingDay>();

            for (var day = firstDayMonth; day <= lastDayMonth; day = day.AddDays(1))
            {
                if (day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday)
                {
                    var beginHour = new DateTime(day.Year, day.Month, day.Day, 8, 0, 0);
                    var endHour = new DateTime(day.Year, day.Month, day.Day, 20, 0, 0);

                    var hoursAvailable = new List<string>();

                    while (beginHour < endHour)
                    {
                        var scheduledHours = schedulings
                            .Where(a => a.DateHourScheduling >= beginHour && a.DateHourScheduling < beginHour.AddHours(1))
                            .ToList(); 

                        var totalPlayersHour = scheduledHours.Sum(a => a.NumberPlayer);

                        if (scheduledHours.Count < 3 && totalPlayersHour < 35)
                        {
                            hoursAvailable.Add(beginHour.ToString("HH:mm"));
                        }

                        beginHour = beginHour.AddHours(1);
                    }

                    daysTimesAvailable.Add(new SchedulingDay
                    {
                        Mouth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                        Year = day.Year,
                        Day = day.Day,
                        HoursAvailable = hoursAvailable
                    });
                }
            }

            monthsAppointments.AddRange(daysTimesAvailable);
        }

        return monthsAppointments;
    }

    public async Task<int> InsertAsync(Scheduling request)
    {
        var idEntity = (await _scheduling.AddAsync(request)).Entity.Id;
        await _context.SaveChangesAsync();

        return idEntity;
    }

    public Task<int> UpdateAsync(Player request)
    {
        throw new NotImplementedException();
    }
}
