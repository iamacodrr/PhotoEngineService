using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace PhotoEngineService.DLL
{
    public class PhotoUploader
    {
        private readonly IConfiguration _config;

        public PhotoUploader(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetStorageConnection()
        {
            return _config.GetValue<string>("ConnectionStrings:azstorage");
        }

        public async Task<bool> UploadPhoto(Stream fileStream, string fileName)
        {
            BlobServiceClient blobSvcClient = new BlobServiceClient(GetStorageConnection());
            string containerName = _config.GetValue<string>("BlobContainers:bmwPhotoContainer");
            BlobContainerClient blobContainerClient = new BlobContainerClient(GetStorageConnection(), containerName);
            blobContainerClient.CreateIfNotExists();
            await blobContainerClient.UploadBlobAsync(fileName, fileStream);
            return await Task<bool>.FromResult(true);
        }
    }
}
