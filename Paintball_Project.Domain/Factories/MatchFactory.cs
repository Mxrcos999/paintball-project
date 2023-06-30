using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class MatchFactory
{
    public static Match Create(int time, int numberBalls, decimal price)
    {
        return new Match(time, numberBalls, price);
    }
}
