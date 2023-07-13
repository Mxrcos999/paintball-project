namespace Paintball_Project.Application.DTOs.Update;

public sealed class ChargeDataUpdateRequest
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int NumberBalls { get; set; }
}
