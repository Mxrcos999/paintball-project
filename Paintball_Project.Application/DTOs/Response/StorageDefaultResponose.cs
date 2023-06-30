namespace Paintball_Project.Application.DTOs.Response;

public sealed class StorageDefaultResponose
{
    public string ErrorMessage { get; set; }
    public bool Success { get; set; }
    public object Content { get; set; }
}
