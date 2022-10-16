namespace CloudStorage.Domain.CloudFiles
{
    public class CloudFilesApplicationService : ICloudFilesApplicationService
    {
        private readonly IGenericRepository<CloudFile> _cloudFilesRepository;

        public CloudFilesApplicationService(IGenericRepository<CloudFile> cloudFilesRepository)
        {
            _cloudFilesRepository = cloudFilesRepository;
        }

        public async Task CreateAsync(CloudFile file)
        {
            await _cloudFilesRepository.CreateAsync(file);
        }

        public List<CloudFile> GetAll()
        {
            return _cloudFilesRepository.GetAll();
        }
    }
}
