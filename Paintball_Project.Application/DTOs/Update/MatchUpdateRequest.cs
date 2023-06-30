namespace Paintball_Project.Application.DTOs.Update;

public sealed class MatchUpdateRequest
{
    public int Id { get; set; }
    public int Time { get; set; }
    public int NumberBalls { get; set; }
    public decimal Price { get; set; }
}
