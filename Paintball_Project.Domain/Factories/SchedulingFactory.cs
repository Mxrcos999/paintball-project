using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class SchedulingFactory
{
    public static Scheduling Create(int numberPlayer, DateTime dateHourScheduling, int durationMatch, string name, string phone)
    {
        return new Scheduling(numberPlayer, dateHourScheduling, durationMatch, name, phone);
    }
}
