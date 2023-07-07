using Paintball_Project.Application.DTOs.Insert;

namespace Paintball_Project.Application.DTOs.Update;

public sealed class SchedulingUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public int NumberPlayer { get; set; }
    public DateTime DateHourScheduling { get; set; }
    public int DurationMatch { get; set; }
}
