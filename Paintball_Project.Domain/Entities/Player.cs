using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class Player : EntityCore
{
    public string Name { get; private set; }
    public string Phone { get; private set; }

    private Player() { }
    internal Player(string name, string phone)
    {
        DateTimeCreating = DateTime.Now.ToUniversalTime();
        Name = name;
        Phone = phone;
    }
}
