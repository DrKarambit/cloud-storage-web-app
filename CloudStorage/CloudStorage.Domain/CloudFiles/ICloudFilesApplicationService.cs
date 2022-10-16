namespace CloudStorage.Domain.CloudFiles
{
    public interface ICloudFilesApplicationService
    {
        Task CreateAsync(CloudFile file);
        List<CloudFile> GetAll();
    }
}