using System.ComponentModel.DataAnnotations;

namespace Paintball_Project.Application.DTOs.Insert;

public sealed class SchedulingInsertRequest
{
    public PlayerInsertRequest Player { get; set; }
    [Required(ErrorMessage = "Informe o número de jogadores.")]
    [Range(8, 40, ErrorMessage = "O jogo deve conter no mínimo 8 e no máximo 40 jogadores.")]
    public int NumberPlayer { get; set; }
    [Required(ErrorMessage = "Informe a data e hora do jogo.")]
    public DateTime DateHourScheduling { get; set; }
    public int DurationMatch { get; set; }
}
