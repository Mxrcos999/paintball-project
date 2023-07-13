namespace Paintball_Project.Application.DTOs.Update;

public sealed class MatchUpdateRequest
{
    public int Id { get; set; }
    public int QuantityMaxPlayers { get; set; }
    public int QuantityMinPlayers { get; set; }
    public int DurationMatch { get; set; }
}
