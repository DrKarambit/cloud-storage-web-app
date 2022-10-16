namespace CloudStorage.Domain.CloudFiles
{
    public interface ICloudFilesApplicationService
    {
        Task CreateAsync(CloudFile file);
        Task<CloudFileDownloadModel> DownloadAsync(Guid fileId, string contentPathRoot);
        Task<List<CloudFile>> GetAllAsync();
    }
}