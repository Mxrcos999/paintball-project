using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.DTOs.Response;

public sealed class MatchResponse
{
    public int Id { get; set; }
    public int QuantityMaxPlayers { get; set; }
    public int QuantityMinPlayers { get; set; }
    public int DurationMatch { get; set; }

    public ICollection<GameData> GameDatas { get; set; }
    public ICollection<ChargeData> ChargeDatas { get; set; }
}
