namespace Paintball_Project.Application.DTOs.Insert;

internal class SchedulingInsertRequest
{
    public string Name { get; set; }
    public DateTime DateTimeRegistration { get; set; }
    public string Phone { get; set; }
    public int NumberPlayers { get; set; }
}
