using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class SchedulingSettingFactory
{
    public static SchedulingSettings Create(int numberPlayer, int duratioinMatch)
    {
        return new SchedulingSettings(numberPlayer, duratioinMatch);
    }
}
