namespace CloudStorage.Domain.CloudFiles
{
    public class CloudFilesApplicationService : ICloudFilesApplicationService
    {
        private readonly IGenericRepository<CloudFile> _cloudFilesRepository;

        public CloudFilesApplicationService(IGenericRepository<CloudFile> cloudFilesRepository)
        {
            _cloudFilesRepository = cloudFilesRepository;
        }

        public List<CloudFile> GetAll()
        {
            return _cloudFilesRepository.GetAll();
        }
    }
}
