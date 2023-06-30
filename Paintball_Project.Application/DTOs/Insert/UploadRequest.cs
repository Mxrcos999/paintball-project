namespace Paintball_Project.Application.DTOs.Insert;

public sealed class UploadRequest
{
    public string Base64Image { get;set; }
    public string ImageName { get; set; }
}
