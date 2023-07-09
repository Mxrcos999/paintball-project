namespace Paintball_Project.Application.DTOs.Insert;

public sealed class MatchInsertRequest
{
    public int QuantityMaxPlayers { get; set; }
    public int QuantityMinPlayers { get; set; }
    public int DurationMatch { get; set; }

    public ICollection<GameDataInsertRequest> GameDatas { get; set; }
    public ICollection<ChargeDataInsertRequest> ChargeDatas { get; set; }
}
