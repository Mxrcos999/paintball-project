namespace Paintball_Project.Application.DTOs.Insert;

public sealed class MatchInsertRequest
{
    public int Time { get; set; }
    public int NumberBalls { get; set; }
    public decimal Price { get; set; }
}
