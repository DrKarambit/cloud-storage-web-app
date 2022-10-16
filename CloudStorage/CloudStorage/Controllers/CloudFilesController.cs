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

        public CloudFilesController(ICloudFilesApplicationService cloudFilesApplicationService)
        {
            _cloudFilesApplicationService = cloudFilesApplicationService;
        }

        [HttpPost]
        public async Task PostAsync(CloudFile request)
        {
            await _cloudFilesApplicationService.CreateAsync(request);
        }

        [HttpGet]
        public List<CloudFile> GetAsync()
        {
            return _cloudFilesApplicationService.GetAll();
        }
    }
}
