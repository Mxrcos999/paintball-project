using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class ChargeData : EntityCore
{
    public decimal Price { get; private set; }
    public int NumberBalls { get; private set; }
    public MatchSettings MatchSettings { get; private set; }
    public int MatchSettingsId { get; set; }

    internal ChargeData(decimal price, int numberBalls, MatchSettings matchSettings)
    {
        Price = price;
        NumberBalls = numberBalls;
        MatchSettings = matchSettings;
    }

    private ChargeData() { }

    public void Alterar(decimal price, int numberBalls)
    {
        Price = price;
        NumberBalls = numberBalls;
    }
}
