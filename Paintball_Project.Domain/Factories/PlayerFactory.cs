using Paintball_Project.Domain.Entities;

namespace Paintball_Project.Domain.Factories;

public static class PlayerFactory
{
    public static Player Create(string name, string phone)
    {
        return new Player(name, phone);
    }
}
