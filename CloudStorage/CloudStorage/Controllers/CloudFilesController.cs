using CloudStorage.Domain.CloudFiles;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public List<CloudFile> GetAsync()
        {
            return _cloudFilesApplicationService.GetAll();
        }
    }
}
