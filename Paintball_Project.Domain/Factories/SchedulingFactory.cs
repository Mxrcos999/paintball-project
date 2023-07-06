using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class SchedulingFactory
{
    public static Scheduling Create(Player player, int numberPlayer, DateTime dateHourScheduling, int durationMatch)
    {
        return new Scheduling(player, numberPlayer, dateHourScheduling, durationMatch);
    }
}
