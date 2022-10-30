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

        public async Task<List<CloudFile>> GetAllAsync()
        {
            return await _cloudFilesRepository.GetAllAsync();
        }

        public async Task<CloudFileDownloadModel> DownloadAsync(Guid fileId, string contentPathRoot)
        {
            var entity = await _cloudFilesRepository.GetByIdAsync(fileId);

            var result = new CloudFileDownloadModel(null, string.Empty, string.Empty, false);
            if (entity != null)
            {
                var memory = new MemoryStream();
                memory.Write(entity.Content);
                memory.Position = 0;

                result = new CloudFileDownloadModel(memory, entity.Type, entity.Name, true);
            }

            return result;
        }

        public async Task<CloudFileRemoveModel> RemoveAsync(Guid fileId)
        {
            var entity = await _cloudFilesRepository.GetByIdAsync(fileId);

            var result = new CloudFileRemoveModel(Guid.Empty, false);

            if (entity != null)
            {
                await _cloudFilesRepository.RemoveAsync(entity);
                result = new CloudFileRemoveModel(entity.Id, true);     
            }
            return result;

        }
    }
}
