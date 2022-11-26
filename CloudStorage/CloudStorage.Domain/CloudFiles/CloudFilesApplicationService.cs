using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public async Task<CloudFileUpdateLinkModel> UpdateLinkAsync(Guid fileId, bool isNull)
        {
            var entity = await _cloudFilesRepository.GetByIdAsync(fileId);    
            var result = new CloudFileUpdateLinkModel(Guid.Empty, false);

            if (entity != null)
            {
                if(isNull == true)
                {
                    entity.SharingLink = Guid.NewGuid().ToString();
                }
                else
                {
                    entity.SharingLink = null;
                }
                await _cloudFilesRepository.UpdateLink(entity);
                result = new CloudFileUpdateLinkModel(entity.Id, true);
            }
            return result;

        }

        public async Task<GetGuidModel> GetGuidAsync(Guid shareLink)
        {
            var entity = await _cloudFilesRepository.GetIdByShareLinkAsync(shareLink.ToString());
            var result = new GetGuidModel(Guid.Empty, Guid.Empty, string.Empty, string.Empty, 0.0);
            if(entity != null) {
                result = new GetGuidModel(shareLink, entity.Id, entity.Name, entity.Type, entity.Size);
                return result;
            }
            return result;
            
        }

    }
}
