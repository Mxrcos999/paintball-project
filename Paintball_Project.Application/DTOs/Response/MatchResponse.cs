using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Application.DTOs.Response;

public sealed class MatchResponse
{
    public int Id { get; set; }
    public int QuantityMaxPlayers { get; set; }
    public int QuantityMinPlayers { get; set; }
    public List<int> DurationMatch { get; set; } = new List<int>();

    public ICollection<GameDataResponse> GameDatas { get; set; }
    public ICollection<ChargeDataResponse> ChargeDatas { get; set; }
}
