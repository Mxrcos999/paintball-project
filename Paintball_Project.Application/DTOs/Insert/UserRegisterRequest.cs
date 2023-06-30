namespace Paintball_Project.Application.DTOs.Insert;

public class UserRegisterRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmEmail { get; set; }
}
