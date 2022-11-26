namespace CloudStorage.Domain.CloudFiles
{
    public interface ICloudFilesApplicationService
    {
        Task CreateAsync(CloudFile file);
        Task<CloudFileDownloadModel> DownloadAsync(Guid fileId, string contentPathRoot);
        Task<CloudFileRemoveModel> RemoveAsync(Guid fileId);
        Task<List<CloudFile>> GetAllAsync();
        Task<CloudFileUpdateLinkModel> UpdateLinkAsync(Guid fileId, bool isNull);
        Task<GetGuidModel> GetGuidAsync(Guid sharingLink);  
      
    }
}