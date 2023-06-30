// See https://aka.ms/new-console-template for more information
using Paintball_Project.Storage.Services;
public static class a
{
    public static void Main() 
    {
        teste();
    }
    public async static Task teste()
    {
        var blob = new AzureStorageService();
        await blob.UploadImageAsync();
    }

}
