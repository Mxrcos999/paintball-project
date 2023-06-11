using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class Scheduling : EntityCore
{
    public string Name { get; private set; }
    public DateTime DateTimeRegistration { get; private set; }
    public string Phone { get; private set; }
    public int NumberHours { get; private set; } = 1;
    public int NumberPlayers { get; private set; }

    private Scheduling() { }
    internal Scheduling(string name, DateTime dateTimeRegistration, string phone, int numberPlayers)
    {
        Name = name;
        DateTimeRegistration = dateTimeRegistration;
        Phone = phone;
        NumberPlayers = numberPlayers;
    }
}
