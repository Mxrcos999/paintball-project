using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class Match : EntityCore
{
    public int Time { get; private set; }
    public int NumberBalls { get; private set; }
    public decimal Price { get; private set; }
    private Match() { }
    internal Match(int time, int numberBalls, decimal price)
    {
        Time = time;
        NumberBalls = numberBalls;
        Price = price;
    }

    public void Alterar(int time, int numberBalls, decimal price)
    {
        Time = time;
        NumberBalls = numberBalls;
        Price = price;
    }
}
