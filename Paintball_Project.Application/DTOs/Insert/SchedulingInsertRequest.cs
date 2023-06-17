using System.ComponentModel.DataAnnotations;

namespace Paintball_Project.Application.DTOs.Insert;

public sealed class SchedulingInsertRequest
{
    public PlayerInsertRequest Player { get; set; }
    [MinLength(8, ErrorMessage = "É nécessario 8 jogadores.")]
    [Required(ErrorMessage = "Informe o número de jogadores.")]
    public int NumberPlayer { get; set; }
    [Required(ErrorMessage = "Informe a data e hora do jogo.")]
    public DateTime DateHourScheduling { get; set; }
}
