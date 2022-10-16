using CloudStorage.Domain.CloudFiles;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorage.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CloudFilesController : ControllerBase
    {
        private readonly ICloudFilesApplicationService _cloudFilesApplicationService;
        private readonly IHostEnvironment _environment;

        public CloudFilesController(
            ICloudFilesApplicationService cloudFilesApplicationService,
            IHostEnvironment environment)
        {
            _cloudFilesApplicationService = cloudFilesApplicationService;
            _environment = environment;
        }

        [HttpPost]
        public async Task PostAsync(CloudFile request)
        {
            await _cloudFilesApplicationService.CreateAsync(request);
        }

        [HttpGet]
        public async Task<List<CloudFile>> GetAllAsync()
        {
            return await _cloudFilesApplicationService.GetAllAsync();
        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> DownloadAsync([FromQuery] Guid fileId)
        {
            var result = await _cloudFilesApplicationService.DownloadAsync(fileId, _environment.ContentRootPath);

            if(!result.FileGenerationSuccess)
            {
                return NotFound();
            }

            return File(result.Stream, result.ContentType,result.FileName);
        }
    }
}
