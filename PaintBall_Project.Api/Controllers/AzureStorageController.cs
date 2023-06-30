using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.Interfaces.Services;

namespace PaintBall_Project.Api.Controllers;
[ApiController]
[Route("storage")]
public class AzureStorageController : Controller
{
    private readonly IAzureStorageService _azureStorageService;
    public AzureStorageController(IAzureStorageService azureStorageService)
    {
        _azureStorageService = azureStorageService;
    }

    [HttpPost]
    public async Task<ActionResult> UploadImageAsync([FromBody] UploadRequest uploadRequest)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        await _azureStorageService.UploadImageAsync(uploadRequest);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> StorageDownload(string imageName)
    {
        var downloadResponse = await _azureStorageService.DownloadImageAsync(imageName);

        return File(downloadResponse.Value.Content, downloadResponse.Value.ContentType, imageName + ".jpg");

    }
}
