using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class GameDataFactory
{
    public static GameData Create(decimal price, int numberBalls, int time)
    {
        return new GameData
            (price,
            numberBalls,
            time);
    }
}
