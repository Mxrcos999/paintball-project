namespace Paintball_Project.Application.DTOs.Response;

public sealed class SchedulingResponse
{
    public string PlayerName { get; set; }
    public DateTime DateTimeRegistration { get; set; }
    public DateTime DateTimeScheduling { get; set; }
    public string Phone { get; set; }
    public int NumberPlayers { get; set; }
}
