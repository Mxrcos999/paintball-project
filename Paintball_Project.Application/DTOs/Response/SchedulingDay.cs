namespace Paintball_Project.Application.DTOs.Response;

public sealed class SchedulingDay
{
    public string Mouth { get; set; }
    public int Year { get; set; }
    public int Day { get; set; }
    public List<string> HoursAvailable { get; set; }
}
