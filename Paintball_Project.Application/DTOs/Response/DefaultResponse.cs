namespace Paintball_Project.Application.DTOs.Response;

public sealed class DefaultResponse
{
    public bool Sucess { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public void AddError(string message)
    {
        Errors.Add(message);
    }
}
