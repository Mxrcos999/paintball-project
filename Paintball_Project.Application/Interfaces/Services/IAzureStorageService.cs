using Azure;
using Azure.Storage.Blobs.Models;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;

namespace Paintball_Project.Application.Interfaces.Services;

public interface IAzureStorageService
{
    Task UploadImageAsync(UploadRequest uploadRequest);
    Task<Response<BlobDownloadInfo>> DownloadImageAsync(string destinationFilePath);
}
