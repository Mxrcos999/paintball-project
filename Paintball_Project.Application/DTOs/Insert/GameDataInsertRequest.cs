namespace Paintball_Project.Application.DTOs.Insert;

public sealed class GameDataInsertRequest
{
    public decimal Price { get; set; }
    public int NumberBalls { get; set; }
    public int Time { get; set; }
}
