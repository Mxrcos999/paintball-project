using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class ChargeDataFactory
{
    public static ChargeData Create(decimal price, int numberBalls, MatchSettings matchSettings)
    {
        return new ChargeData(price, numberBalls, matchSettings);
    }
}
