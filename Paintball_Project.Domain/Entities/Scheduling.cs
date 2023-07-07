using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class Scheduling : EntityCore
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public int DurationMatch { get; private set; }
    public int NumberPlayer { get; private set; }
    public DateTime DateHourScheduling { get; private set; }

    private Scheduling() { }
    internal Scheduling(int numberPlayer, DateTime dateHourScheduling, int durationMatch, string name, string phone)
    {
        DateTimeCreating = DateTime.Now.ToUniversalTime();
        NumberPlayer = numberPlayer;
        DateHourScheduling = dateHourScheduling;
        DurationMatch = durationMatch;
        Name = name;
        Phone = phone;
    }

    public void Alterar(int numberPlayer, DateTime dateHourScheduling, int durationMatch, string name, string phone)
    {
        DateTimeChange = DateTime.Now.ToUniversalTime();
        NumberPlayer = numberPlayer;
        DateHourScheduling = dateHourScheduling;
        DurationMatch = durationMatch;
        Name = name;
        Phone = phone;
    }
}
