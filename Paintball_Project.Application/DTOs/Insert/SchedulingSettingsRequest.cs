namespace Paintball_Project.Application.DTOs.Insert;

public sealed class SchedulingSettingsRequest
{
    public int Id { get; set; }
    /// <summary>
    /// Indica o número de jogadores que podem jogar em um agendamento
    /// </summary>
    public int NumberPlayer { get; set; }
    /// <summary>
    /// Indica quanto tempo uma partida dura (em horas)
    /// </summary>
    public int DurationMatch { get; set; }
}
