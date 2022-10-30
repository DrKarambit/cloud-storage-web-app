using AutoMapper;
using CloudStorage.ApiModels;
using CloudStorage.Domain.CloudFiles;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorage.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CloudFilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICloudFilesApplicationService _cloudFilesApplicationService;
        private readonly IHostEnvironment _environment;

        public CloudFilesController(
            IMapper mapper,
            ICloudFilesApplicationService cloudFilesApplicationService,
            IHostEnvironment environment)
        {
            _mapper = mapper;
            _cloudFilesApplicationService = cloudFilesApplicationService;
            _environment = environment;
        }
        [HttpPost]
        public async Task PostAsync(CreateUpdateCloudFileDto request)
        {
            var cloudFile = _mapper.Map<CloudFile>(request);
            await _cloudFilesApplicationService.CreateAsync(cloudFile);
        }

        [HttpPost]
        [Route("delete")]
        public async Task RemoveAsync(RemoveFileDto request)
        {
            var cloudFile = request ;
            await _cloudFilesApplicationService.RemoveAsync(cloudFile.Id);
        
        }
        [HttpGet]
        public async Task<List<CloudFileDto>> GetAllAsync()
        {
            var domainResult = await _cloudFilesApplicationService.GetAllAsync();
            var result = _mapper.Map<List<CloudFileDto>>(domainResult);
            return result;
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
