using System.ComponentModel.DataAnnotations;

namespace Paintball_Project.Application.DTOs.Insert;

public sealed class PlayerInsertRequest
{
    [Required(ErrorMessage = "Informe seu nome.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Informe seu número de telefone.")]
    [MaxLength(12, ErrorMessage = "Informe um número de telefone válido, Ex: (00-00000-0000)")]
    public string Phone { get; set; }
}
