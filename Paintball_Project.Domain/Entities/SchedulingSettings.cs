using Paintball_Project.Domain.Entities.EntitiesCore;

namespace Paintball_Project.Domain.Entities;

public class SchedulingSettings : EntityCore
{
    /// <summary>
    /// Indica o número de jogadores que podem jogar em um agendamento
    /// </summary>
    public int NumberPlayer { get; private set; }
    /// <summary>
    /// Indica quanto tempo uma partida dura (em horas)
    /// </summary>
    public int DurationMatch { get; private set; }
    private SchedulingSettings() { }
    internal SchedulingSettings(int numberPlayer, int duratioinMatch)
    {
        NumberPlayer = numberPlayer;
        DurationMatch = duratioinMatch; 
    }

    public void Update(int numberPlayer, int durationMatch)
    {
        NumberPlayer = numberPlayer;
        DurationMatch = durationMatch;
    }
}
