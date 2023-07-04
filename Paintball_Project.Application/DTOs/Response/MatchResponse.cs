namespace Paintball_Project.Application.DTOs.Response;

public sealed class MatchResponse
{
    public int Time { get; set; }
    public int NumberBalls { get; set; }
    public decimal Price { get; set; }
    public bool isRecharge { get; set; }
}
