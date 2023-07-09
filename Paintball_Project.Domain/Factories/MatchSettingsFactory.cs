using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class MatchSettingsFactory
{
    public static MatchSettings Create(int quantityMaxPlayers, int quantityMinPlayers, int durationMatch, ICollection<GameData> gameData, ICollection<ChargeData> chargeData)
    {
        return new MatchSettings
            (quantityMaxPlayers, 
            quantityMinPlayers,
            durationMatch,
            gameData,
            chargeData);
    }
}
