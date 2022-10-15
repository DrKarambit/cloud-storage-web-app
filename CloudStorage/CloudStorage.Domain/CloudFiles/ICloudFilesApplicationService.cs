namespace CloudStorage.Domain.CloudFiles
{
    public interface ICloudFilesApplicationService
    {
        List<CloudFile> GetAll();
    }
}