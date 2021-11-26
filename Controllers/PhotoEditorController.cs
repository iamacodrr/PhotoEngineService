using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhotoEngineService.DLL;
using System.IO;
using System.Threading.Tasks;

namespace PhotoEngineService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoEditorController : ControllerBase
    {
        public IConfiguration _config;

        public PhotoEditorController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<bool> UploadPhotoToBlob()
        {
            PhotoUploader objUploader = new PhotoUploader(_config);
            bool isUploaded = false;
            var httpRequest = HttpContext.Request;
            //Upload Image
            //var postedFile = httpRequest.["Image"];
            //isUploaded = await objUploader.UploadPhoto(fileStream, fileName);
            return isUploaded;
        }

    }
}
