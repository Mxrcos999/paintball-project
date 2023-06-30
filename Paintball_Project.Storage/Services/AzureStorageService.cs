using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.Interfaces.Services;
using System.Text.RegularExpressions;

namespace Paintball_Project.Storage.Services;

public class AzureStorageService : IAzureStorageService
{
    private readonly BlobServiceClient _blobClient;
    public AzureStorageService(BlobServiceClient blobClient)
    {
        string storageAccountName = "paintballstorage";
        string storageAccountKey = "rqKu/8zhwe7fZRUojXPB1Emi9byiA8WGMkjYWEG8NnWvGzFMlk/4CL1y2KBmuKOjCEh/6n08WxBi+ASt+AaUTA==";

        _blobClient = new
         BlobServiceClient
         ($"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey};EndpointSuffix=core.windows.net"); ;
    }
    public async Task UploadImageAsync(UploadRequest uploadRequest)
    {
        string containerName = "imagespaintball";

        var containerClient = _blobClient.GetBlobContainerClient(containerName);

        if (!await containerClient.ExistsAsync())
        {
            await containerClient.CreateAsync();
            await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
        }

        var blobClient = containerClient.GetBlobClient(uploadRequest.ImageName);

        var imageStream = ConvertImageToStream(uploadRequest.Base64Image, blobClient);


    }

    public async Task<Response<BlobDownloadInfo>> DownloadImageAsync(string imageName)
    {
        string containerName = "imagespaintball";
        try
        {
            BlobContainerClient containerClient = _blobClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(imageName);

            Response<BlobDownloadInfo> result = await blobClient.DownloadAsync();

            return result;
        }
        catch (RequestFailedException ex)
        {
            throw ex;
        }
      
    }

    private async Task ConvertImageToStream(string base64Image, BlobClient blobClient)
    {
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

        byte[] imageBytes = Convert.FromBase64String(data);

        using (var stream = new MemoryStream(imageBytes))
        {
            var result = await blobClient.UploadAsync(stream, true);
        }
    }

}
