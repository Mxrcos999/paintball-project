namespace Paintball_Project.Application.DTOs.Response;

public sealed class SchedulingSettingsResponse
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
