namespace Paintball_Project.Application.DTOs.Update;

public sealed class GameDataUpdateRequest
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int NumberBalls { get; set; }
    public int Time { get; set; }
}
