using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class SchedulingFactory
{
    public static Scheduling Create(string name, DateTime dateTimeRegistration, string phone, int numberHours, int numberPlayers)
    {
        return new Scheduling(name, dateTimeRegistration, phone, numberPlayers);
    }
}
