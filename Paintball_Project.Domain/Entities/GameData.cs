using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public class GameData : EntityCore
{
    public decimal Price { get; private set; }
    public int NumberBalls { get; private set; }
    public int Time { get; private set; }
    public MatchSettings MatchSettings { get; private set; }
    public int MatchSettingsId { get; set; }
    internal GameData(decimal price, int numberBalls, int time, MatchSettings match)
	{
        Price = price;
        NumberBalls = numberBalls;
        Time = time;
        MatchSettings = match;
	}
	private GameData() { }

    public void Alterar(decimal price, int numberBalls, int time)
    {
        Price = price;
        NumberBalls = numberBalls;
        Time = time;
    }
}
