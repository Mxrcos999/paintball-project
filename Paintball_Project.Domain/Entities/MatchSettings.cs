using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class MatchSettings : EntityCore
{
    public int QuantityMaxPlayers { get; private set; }
    public int QuantityMinPlayers { get; private set; }
    public int DurationMatch { get; private set; }

    public ICollection<GameData> GameDatas { get; private set; }
    public ICollection<ChargeData> ChargeDatas { get; private set; }
    
    private MatchSettings() { }
    internal MatchSettings(int quantityMaxPlayers, int quantityMinPlayers, int durationMatch, ICollection<GameData> gameData, ICollection<ChargeData> chargeData)
    {
        QuantityMaxPlayers = quantityMaxPlayers;
        QuantityMinPlayers = quantityMinPlayers;
        GameDatas = gameData;
        ChargeDatas = chargeData;
        DurationMatch = durationMatch;
    }

    public void Alterar(int quantityMaxPlayers,
        int quantityMinPlayers, int durationMatch)
    {
        QuantityMaxPlayers = quantityMaxPlayers;
        QuantityMinPlayers = quantityMinPlayers;
        DurationMatch = durationMatch;
    }
}
