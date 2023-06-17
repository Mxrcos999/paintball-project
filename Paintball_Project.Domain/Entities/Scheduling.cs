using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public sealed class Scheduling : EntityCore
{
    public int PlayerId { get; private set; }
    public Player Player { get; private set; }
    public int NumberPlayer { get; private set; }
    public DateTime DateHourScheduling { get; private set; }
    private Scheduling() { }
    internal Scheduling(Player player, int numberPlayer, DateTime dateHourScheduling)
    {
        DateTimeCreating = DateTime.Now.ToUniversalTime();
        Player = player;
        NumberPlayer = numberPlayer;
        DateHourScheduling = dateHourScheduling;
    }

    public void Alterar(Player player, int numberPlayer, DateTime dateHourScheduling)
    {
        DateTimeChange = DateTime.Now.ToUniversalTime();
        Player = player;
        NumberPlayer = numberPlayer;
        DateHourScheduling = dateHourScheduling;
    }
}
